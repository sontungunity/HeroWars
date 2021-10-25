using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Gafu.Base.Events;
using System;

public class FloorEnemy : FloorBase {
    [SerializeField] private List<Transform> lstPositionChar;
    [SerializeField] private BoxCollider2D collder2D;
    [SerializeField] private GameObject glow;
    public List<CharBase> lstCharBase = new List<CharBase>();
    public GameObject Glow => glow;
    public CharBase CharFace {
        get {
            if(lstCharBase == null || lstCharBase.Count == 0) {
                return null;
            } else {
                return lstCharBase[lstCharBase.Count - 1];
            }
        }
    }
    private void Start() {

    }

    public override void Show(FloorData fData,TowerCS tower) {
        base.Show(fData, tower);
        for(int i = 0; i < fData.LstCharData.Count(); i++) {
            var charData = fData.LstCharData.ElementAt(i);
            var character = DataManager.Instance.GetCharByCharID(charData.CharID).Spawn(transform);
            character.transform.position = lstPositionChar[i].position;
            character.Show(charData.Power, this);
            lstCharBase.Add(character as EnemyNormal);
        }
    }

    public override void SetUpDefault() {
        collder2D.enabled = true;
        glow.SetActive(false);
    }

    public override void HeroOver(bool over) {
        glow.SetActive(over);
    }

    //public override void HeroComeIn(HeroMain hero,Action callback) {
    //    this.HeroComeIn
    //    
    //}
    public override void HeroComeIn(HeroMain hero, Action callBack) {
        collder2D.enabled = false;
        base.HeroComeIn(hero, callBack);
    }

    public override void HeroComeOut() {
        base.HeroComeOut();
        Tower.Remove(this);
    }

    public override void Clear() {
        base.Clear();
        foreach(var charE in lstCharBase) {
            charE.Recycle();
        }
        lstCharBase.Clear();
    }

    public void RemoveChase(CharBase charB) {
        lstCharBase.Remove(charB);
    }

    private void OnMouseEnter() {
        glow.SetActive(true);
    }

    private void OnMouseExit() {
        glow.SetActive(false);
    }

    private void OnMouseUp() {
        glow.SetActive(false);
        EventDispatcher.Dispatch<EventKey.SelectFloor>(new EventKey.SelectFloor(this));
    }
}
