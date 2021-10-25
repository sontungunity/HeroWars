using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FloorBase : MonoBehaviour {
    [SerializeField] private SpriteRenderer boundFloor;
    [SerializeField] protected Transform heroPosition;
    public HeroMain Hero = default;
    public TowerCS Tower;
    public FloorData FloorData;
    public float HightFloor => boundFloor.size.y;
    protected Transform HeroPosition => heroPosition;
    private Tween tween;
    private Coroutine coroutine;
    public virtual void SetUpHeroPosition(HeroMain hero) {
        hero.transform.position = heroPosition.position;
        Debug.Log("Finish hero setPosition");
    }

    public virtual void Show(FloorData fData, TowerCS tower) {
        this.FloorData = fData;
        this.Tower = tower;
        SetUpDefault();
    }

    public virtual void HeroOver(bool over) {

    }

    public virtual void HeroComeIn(HeroMain hero, Action callBack) {
        this.Hero = hero;
        Hero.transform.parent = transform;
        SetUpHeroPosition(Hero);
        StartCoroutine(WaitingTowerBuld(callBack));
    }

    IEnumerator WaitingTowerBuld(Action callBack) {
        yield return new WaitUntil(() => Tower.STT == TowerCS.Status.IDLE);
        callBack?.Invoke();
        yield return null;
    }

    public virtual void HeroComeOut() {
        this.Hero.transform.parent = null;
        this.Hero = null;
    }

    public virtual void SetUpDefault() {

    }

    public virtual void Clear() {
        if(this.Hero != null) {
            this.Hero.Recycle();
            this.Hero = null;
        }
    }

    public void Move(float hightFloor, float timeMove = 0.5f) {
        tween = transform.DOLocalMoveY(transform.localPosition.y + hightFloor, timeMove).SetEase(Ease.OutBack);
    }

    private void OnDisable() {
        tween.CheckKillTween();
    }

    private void OnDestroy() {
        tween.CheckKillTween();
    }
}
