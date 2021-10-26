using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CharBase
{
    [SerializeField] private Sprite imgWeapon;
    [SerializeField] private bool leftHand = true;
    public Sprite ImgWeapon => imgWeapon;

    public void Equipment(HeroMain heroMain, Action callback = null) {
        transform.localScale = Vector3.zero;
        heroMain.AddPower(Power);
        if(leftHand) {
            heroMain.LeftHand.Equitment(CharID,imgWeapon);
        } else {
            heroMain.RightHand.Equitment(CharID, imgWeapon);
        }
        this.Recycle();
        callback?.Invoke();
    }

    public override void SetUpDefault() {
        base.SetUpDefault();
        transform.localScale = Vector3.one;
    }
}
