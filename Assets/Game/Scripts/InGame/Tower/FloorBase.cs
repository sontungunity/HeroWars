using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBase : MonoBehaviour {

    [SerializeField] protected Transform heroPosition;
    protected Transform HeroPosition => heroPosition;
    protected List<CharBase> lstCharBase = new List<CharBase>();
    public virtual void SetUpHeroPosition(HeroMain hero) {
        hero.transform.position = heroPosition.position;
        Debug.Log("Finish hero setPosition");
    }

    public virtual void Show(FloorData fData) {
        foreach(CharData cData in fData.LstCharData) {
            if(cData.CharID == CharID.HERO) {
                var hero = DataManager.Instance.GetCharByCharID(CharID.HERO).Spawn(transform);
                hero.transform.position = heroPosition.position;
            }
        }
    }
}
