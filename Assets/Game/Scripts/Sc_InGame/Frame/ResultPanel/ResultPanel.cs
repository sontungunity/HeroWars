using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : FrameBase {
    [Header("PAGE")]
    [SerializeField] private TextMeshProUGUI txt_Result;
    [SerializeField] private Button btn_Home;
    [SerializeField] private Button btn_AddCoin;
    [SerializeField] private Button btn_Next;
    [SerializeField] private Button btn_SkipLvl;
    [SerializeField] private Button btn_Replay;
    [SerializeField] private DisplayObjects obj_BtnStyle; // 0. Win, 1. Loser


    private void Awake() {
        btn_Home.onClick.AddListener(() => SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_HOME));
        btn_AddCoin.onClick.AddListener(() => {
            btn_AddCoin.gameObject.SetActive(false);
            DataManager.Instance.PlayerData.AddCoin(100);
        });
        btn_Next.onClick.AddListener(NextLevel);
        btn_SkipLvl.onClick.AddListener(SkipLevel);
        btn_Replay.onClick.AddListener(Replay);
    }

    public void Show(bool result) {
        txt_Result.text = result ? "Win" : "Loser";
        obj_BtnStyle.Active(result ? 0 : 1);
        btn_AddCoin.gameObject.SetActive(result);
    }

    public void SkipLevel() {
        this.Hide();
        GamePlayManager.Instance.SkipLevel();
    }

    public void NextLevel() {
        this.Hide();
        GamePlayManager.Instance.NextLevel();
    }

    public void Replay() {
        this.Hide();
        GamePlayManager.Instance.Replay();
    }
}
