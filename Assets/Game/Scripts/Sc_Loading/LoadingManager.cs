using DG.Tweening;
using Gafu.Base.Events;
using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] private Image cur_;
    private Tween tween;
    private void OnEnable()
    {
        EventDispatcher.AddListener<EventKey.LoadFinal>(LoadHome);
    }

    private void OnDisable()
    {
        EventDispatcher.RemoveListener<EventKey.LoadFinal>(LoadHome);
    }
    private void Start()
    {
        cur_.transform.localScale = new Vector3(0, 1, 1);
        cur_.transform.DOScaleX(0.8f,0.5f);
    }

    private void LoadHome(EventKey.LoadFinal evt)
    {
        SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_HOME);
    }
}

