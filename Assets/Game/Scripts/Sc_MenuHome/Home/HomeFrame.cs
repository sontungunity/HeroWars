using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HomeFrame : FrameBase
{
    [Space]
    [Header("InFrame")]
    [SerializeField] private Button btn_Start;
    [SerializeField] private TextMeshProUGUI txt_Level;
    private void Awake() {
        btn_Start.onClick.AddListener(StartGame);
    }
    public override void OnShow() {
        base.OnShow();
        txt_Level.text = DataManager.Instance.PlayerData.Level.ToString();
    }

    private void StartGame() {
        SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_GAME);
    }
}
