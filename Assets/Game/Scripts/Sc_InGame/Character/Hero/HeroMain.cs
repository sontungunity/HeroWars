using Gafu.Base.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class HeroMain : CharBase {
    [Header("Info")]
    [SerializeField] private HeroTourch hr_Tourch;
    [SerializeField] private Transform display;
    [SerializeField] private TextMeshPro txtStatus;
    [Header("Cur")]
    public int Cur_Power;
    [SerializeField] private Status status;
    private Tween tween;
    private void Awake() {
        hr_Tourch.Init(this);
    }

    private void OnEnable() {
        EventDispatcher.AddListener<EventKey.SelectFloor>(EvtSelectFloor);
    }

    private void OnDisable() {
        EventDispatcher.RemoveListener<EventKey.SelectFloor>(EvtSelectFloor);
    }

    private void OnDestroy() {
        EventDispatcher.RemoveListener<EventKey.SelectFloor>(EvtSelectFloor);
    }

    private void Start() {
        status = Status.IDEL;
        txtStatus.text = "IDEL";
        this.Cur_Power = Power;
    }

    private void EvtSelectFloor(EventKey.SelectFloor evt) {
        Debug.Log("Hero_Telepost");
        status = Status.ACTION;
        txtStatus.text = "ACTION";
        Floor.HeroComeOut();
        Floor = evt.Floor;
        Floor.HeroComeIn(this, HandleFloor);
    }

    #region AffterTourch
    public void AffterTourch(FloorEnemy floorEnemy) {
        Debug.Log("Hero_Draw");
        if(floorEnemy != null) {
            Floor.HeroComeOut();
            this.Floor = floorEnemy;
            Floor.HeroComeIn(this, HandleFloor);
        } else {
            Floor.SetUpHeroPosition(this);
        }

    }
    #endregion

    #region HandlerFloor
    public void HandleFloor() {
        if(Floor is FloorEnemy floorE) {
            status = Status.ACTION;
            HandleCharFace(floorE, () => {
                status = Status.IDEL;
                txtStatus.text = "IDEL";
                GamePlayManager.Instance.CheckWin(); 
            });
        }
    }

    public void HandleCharFace(FloorEnemy floorE, Action callback) {
        CharBase charFace = floorE.CharFace;
        if(charFace != null) {
            ActionDetail(charFace, () => {
                if(status != Status.DIE) {
                    floorE.RemoveChase(charFace);
                    HandleCharFace(floorE, callback);
                } else {
                    OnLoser();
                }
            });
        } else {
            callback?.Invoke();
        }
    }

    // ActionDetail: [Action_Attack,]
    public void ActionDetail(CharBase charG, Action callBack) {
        if(charG is CharCompare charCompare) {
            if(charCompare.ActionType == ActionType.Attack) {
                Action_Attack(charCompare, callBack);
            }

        }
    }


    public void Action_Attack(CharCompare charCompare, Action callback = null) {
        tween = display.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => {
            tween = display.DOScale(Vector3.one, 0.5f).OnComplete(() => {
                if(Cur_Power > charCompare.Power) {
                    charCompare.CompareLose(this);
                    callback?.Invoke();
                } else {
                    charCompare.CompareWin(this);
                    callback?.Invoke();
                }

            });
        });
    }

    public void AddPower(int power, Action callback = null) {
        Cur_Power += power;
        TxtPower.Show(Cur_Power, true, callback: callback);
        if(Cur_Power <= 0) {
            status = Status.DIE;
        }
    }

    public void Win() {
        status = Status.WIN;
        txtStatus.text = "Win";
    }


    private void OnLoser() {

    }
    #endregion

    public enum Status {
        IDEL,
        ACTION,
        WIN,
        DIE
    }

    public enum ActionType {
        Attack,
        UnLock,
    }
}
