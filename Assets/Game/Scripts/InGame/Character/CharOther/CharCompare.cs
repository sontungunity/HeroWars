using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class CharCompare : CharBase {
    [SerializeField] private HeroMain.ActionType actionType;
    [SerializeField] private GameObject display;

    public HeroMain.ActionType ActionType => actionType;
    public Tween tween;

    public FloorEnemy FloorE {
        get {
            if(Floor is FloorEnemy floorE) {
                return floorE;
            } else {
                return null;
            }
        }
    }
    public void CompareWin(HeroMain hero, Action callBack = null) {
        tween = transform.DOScale(new Vector3(1.2f,1.2f,1.2f), 0.2f).OnComplete(() => {
            hero.AddPower(-Power);
            callBack?.Invoke();
        });
    }

    public void CompareLose(HeroMain hero, Action callBack = null) {
        tween = transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => {
            TxtPower.Show(0, true,callback:()=> {
                this.Recycle();
                hero.AddPower(Power);
                callBack?.Invoke();
            });
        });
    }

    private void OnDisable() {
        tween.Kill();
    }

    private void OnDestroy() {
        tween.Kill();
    }
}
