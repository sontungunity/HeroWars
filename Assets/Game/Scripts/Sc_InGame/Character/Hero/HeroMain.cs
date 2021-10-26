using Gafu.Base.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class HeroMain : CharBase {
    [Header("Info")]
    [SerializeField] private HeroHand rightHand;
    [SerializeField] private HeroHand leftHand;
    public HeroHand RightHand => rightHand;
    public HeroHand LeftHand => leftHand;
    [Space]
    [SerializeField] private HeroTourch hr_Tourch;
    [SerializeField] private Transform display;
    [SerializeField] private TextMeshPro txtStatus;
    [SerializeField] private Vector3 spaceTarget;

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

    public override void SetUpDefault() {
        base.SetUpDefault();
        rightHand.Clear();
        leftHand.Clear();
    }
    private void EvtSelectFloor(EventKey.SelectFloor evt) {
        if(status != Status.IDEL) {
            return;
        }
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
    //HandlerFloor=> (selectChar)HandleCharFace => ActionDetail:[....]
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
    //
    // ActionDetail: [Action_Attack,Action_Weapon]
    public void ActionDetail(CharBase charG, Action callBack) {
        if(charG is EnemyNormal charCompare) {
            Action_Attack(charCompare, callBack);
        } else if(charG is Weapon weapon) {
            Action_Weapon(weapon, callBack);
        } else if(charG is Harmful harmful) {
            Action_Harmful(harmful, callBack);
        } else if(charG is CharCodition codition) {
            Action_Condition(codition, callBack);
        }
    }

    private void Action_Condition(CharCodition condition, Action callBack) {
        MoveTarget(condition.transform.localPosition, () => {
            status = Status.WIN;
            txtStatus.text = "IDEL";
            GamePlayManager.Instance.SetUpWin();
            //callBack?.Invoke();
        });
    }

    private void Action_Attack(EnemyNormal charCompare, Action callback = null) {
        tween = display.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.2f).OnComplete(() => {
            tween = display.DOScale(Vector3.one, 0.5f).OnComplete(() => {
                if(Cur_Power > charCompare.Power) {
                    charCompare.CompareLose(this, callback);
                } else {
                    charCompare.CompareWin(this, callback);
                }

            });
        });
    }

    private void Action_Weapon(Weapon weapon, Action callback = null) {
        //tween = transform.DOLocalMove(weapon.transform.localPosition + spaceTarget, 1f).OnComplete(() => {
        //    weapon.Equipment(this, callback);
        //});
        MoveTarget(weapon.transform.localPosition, () => {
            weapon.Equipment(this, callback);
        });
    }

    private void Action_Harmful(Harmful harmful, Action callback = null) {
        MoveTarget(harmful.transform.localPosition, () => {
            harmful.Harm(this, callback);
        });
    }

    public void MoveTarget(Vector3 target, Action callback = null) {
        tween = transform.DOLocalMove(target + spaceTarget, 1f).OnComplete(() => {
            callback?.Invoke();
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

    public void Loser() {
        status = Status.DIE;
        txtStatus.text = "Die";
    }


    private void OnLoser() {
        GamePlayManager.Instance.SetUpLoser();
    }
    #endregion

    public enum Status {
        IDEL,
        ACTION,
        WIN,
        DIE
    }
}
