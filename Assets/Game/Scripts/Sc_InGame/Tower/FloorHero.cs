using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHero : FloorBase
{
    public override void Show(FloorData fData,TowerCS tower) {
        base.Show(fData, tower);
        foreach(CharData cData in fData.LstCharData) {
            if(cData.CharID == CharID.HERO) {
                var hero = DataManager.Instance.GetCharByCharID(CharID.HERO).Spawn(transform) as HeroMain;
                hero.transform.position = heroPosition.position;
                hero.Show(cData.Power,this);
                this.Hero = hero;
                GamePlayManager.Instance.Hero = hero;
            }
        }
    }
}
