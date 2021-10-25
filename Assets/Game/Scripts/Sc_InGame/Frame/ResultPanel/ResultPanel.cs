using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : FrameBase
{
    [Header("PAGE")]
    [SerializeField] private TextMeshProUGUI txt_Result;
    [SerializeField] private Button btn_Home;
    [SerializeField] private Button btn_AddCoin;
    [SerializeField] private Button btn_Next;
    [SerializeField] private DisplayObjects obj_BtnStyle; // 0. Win, 1. Loser
    

    private void Awake() {
        btn_Home.onClick.AddListener(()=> SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_HOME));
        btn_AddCoin.onClick.AddListener(()=> {
            btn_AddCoin.gameObject.SetActive(false);
            DataManager.Instance.PlayerData.AddCoin(100);
        });
        btn_Next.onClick.AddListener(NextLevel);
    }

    public void Show(bool result) {
        txt_Result.text = result ? "Win" : "Loser";
        obj_BtnStyle.Active(result ? 0 : 1);
        btn_AddCoin.gameObject.SetActive(result);
    }

    public void NextLevel() {
        GamePlayManager.Instance.level++;
        GamePlayManager.Instance.PlayGame();
        this.Hide();
        FrameManager.Instance.Push<GamePanel>();
    }
}
