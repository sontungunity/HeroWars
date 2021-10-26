using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Gafu.Base.Events;
using System;

public class GamePanel : FrameBase {
    private const string DEFAUL_QUEST_DESCRIPTION = "KILL ALL ENEMY";
    [SerializeField] private Button btn_Home;
    [SerializeField] private Button btn_Replay;
    [SerializeField] private Button btn_Skip;
    [SerializeField] private Button btn_Tower;
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI txt_Description;
    private void Awake() {
        btn_Home.onClick.AddListener(() => { SceneLoader.Instance.LoadSceneAsyn(SceneLoader.SCENE_HOME); });
        btn_Replay.onClick.AddListener(() => { GamePlayManager.Instance.Replay(); });
        btn_Skip.onClick.AddListener(() => { GamePlayManager.Instance.SkipLevel(); });
        btn_Tower.onClick.AddListener(() => { FrameManager.Instance.Push<TowerFrame>(); });
    }

    //private void OnEnable() {
    //    EventDispatcher.AddListener<EventKey.LoadLevel>(SetUpDesciption);
    //}

    //private void OnDisable() {
    //    EventDispatcher.RemoveListener<EventKey.LoadLevel>(SetUpDesciption);
    //}

    //private void SetUpDesciption(EventKey.LoadLevel evt) {
    //    if(evt.charCodition == CharID.E_NORMAL) {
    //        txt_Description.text = DEFAUL_QUEST_DESCRIPTION;
    //    } else {
    //        CharCodition charC = evt.charCodition.GetCharPrefByCharID() as CharCodition;
    //        txt_Description.text = charC.Description;
    //    }
    //}
    public override void OnShow() {
        base.OnShow();
        AffterLoadLevel(GamePlayManager.Instance.level,GamePlayManager.Instance.IdCharCodition);
    }

    public void AffterLoadLevel(int level, CharID charCodition) {
        if(charCodition == CharID.E_NORMAL) {
            txt_Description.text = DEFAUL_QUEST_DESCRIPTION;
        } else {
            CharCodition charC = charCodition.GetCharPrefByCharID() as CharCodition;
            txt_Description.text = charC.Description;
        }
    }
}
