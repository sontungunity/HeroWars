using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloorEnemy : FloorBase {
    [SerializeField] private List<Transform> lstPositionChar;

    public override void Show(FloorData fData) {
        //int indexPositionChar = 0;
        //foreach(CharData cData in fData.LstCharData) {
        //    if(cData.CharID == CharID.HERO) {
        //        var hero = DataManager.Instance.GetCharByCharID(CharID.HERO).Spawn(transform);
        //        hero.transform.position = heroPosition.position;
        //        lstCharBase.Add(hero);
        //    } else {
        //        var character = DataManager.Instance.GetCharByCharID(CharID.HERO).Spawn(transform);
        //        character.transform.position = 
        //    }
        //}

        for(int i = 0; i < fData.LstCharData.Count(); i++) {
            var charData = fData.LstCharData.ElementAt(i);
            var character = DataManager.Instance.GetCharByCharID(charData.CharID).Spawn(transform);
            character.transform.position = lstPositionChar[i].position;
            character.Show(charData.Power);
            lstCharBase.Add(character);
        }
    }
}
