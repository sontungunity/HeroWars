using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeFrame : FrameBase
{
    [Space]
    [Header("InFrame")]
    [SerializeField] private Button btn_Start;
    private void Awake() {
        btn_Start.onClick.AddListener(StartGame);
    }

    private void StartGame() {
        SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_GAME);
    }
}
