using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GamePanel : FrameBase
{
    [SerializeField] private Button btn_Home;
    [SerializeField] private Button btn_Replay;

    private void Awake() {
        btn_Home.onClick.AddListener(()=> { SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_HOME); });
        btn_Replay.onClick.AddListener(()=> { GamePlayManager.Instance.Replay(); });
    }
}
