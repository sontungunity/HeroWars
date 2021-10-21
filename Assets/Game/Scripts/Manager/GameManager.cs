using DG.Tweening;
using Gafu.Base.Events;
using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int targetFrameRate = 60;
    [SerializeField] private bool multiTouchEnabled = false;
    [SerializeField] private int tweenersCapacity = 500;
    [SerializeField] private int sequencesCapacity = 50;
    [SerializeField] private GameObject[] managers;

    private States state = States.None;
    protected override void OnAwake()
    {
        base.OnAwake();
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = targetFrameRate;
        Input.multiTouchEnabled = multiTouchEnabled;
        DOTween.SetTweensCapacity(tweenersCapacity, sequencesCapacity);
    }

    public void Start()
    {
        StartCoroutine(IElaunch());    
    }

    private IEnumerator IElaunch()
    {
        state = States.Loaded;
        yield return null;
        foreach (GameObject manager in managers)
        {
            Instantiate(manager, transform);
            yield return null;
        }
        yield return null;
        state = States.Started;
        EventDispatcher.Dispatch<EventKey.LoadFinal>(new EventKey.LoadFinal());
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus && (state == States.Started))
        {
            DataManager.Instance.SaveData();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause && (state == States.Started))
        {
            DataManager.Instance.SaveData();
        }
    }

    public void Quit() {
        if(state == States.Started) 
            DataManager.Instance.SaveData();
        state = States.Quiting;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    [Space(5)]
    [Header("Info Game")]
    //InfoGame
    public int Cur_Level = 0;

    public enum States
    {
        None,
        Loaded,
        Started,
        Quiting
    }
}
