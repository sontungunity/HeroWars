using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBase : MonoBehaviour {
    [SerializeField] private SpriteRenderer boundFloor;
    [SerializeField] protected Transform heroPosition;
    public HeroMain Hero = default;
    public float HightFloor => boundFloor.size.y;
    protected Transform HeroPosition => heroPosition;
    public virtual void SetUpHeroPosition(HeroMain hero) {
        hero.transform.position = heroPosition.position;
        Debug.Log("Finish hero setPosition");
    }

    public virtual void Show(FloorData fData) {

    }

    public virtual void HeroOver(bool over) {

    }

    public virtual void HeroComeIn() {

    }

    public virtual void HeroComeOut() {

    }

    public virtual void SetUpDefault() {

    }
}
