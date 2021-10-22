using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHero : FloorBase
{
    public override void Show(FloorData fData) {
        foreach(CharData cData in fData.LstCharData) {
            if(cData.CharID == CharID.HERO) {
                var hero = DataManager.Instance.GetCharByCharID(CharID.HERO).Spawn(transform) as HeroMain;
                hero.transform.position = heroPosition.position;
                hero.Show(cData.Power);
                hero.Cur_Floor = this;
                this.Hero = hero;
                GamePlayManager.Instance.Hero = hero;
            }
        }
    }
}
