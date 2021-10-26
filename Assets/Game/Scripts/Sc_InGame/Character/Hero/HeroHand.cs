using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHand : MonoBehaviour
{
    [SerializeField] private CharID charID;
    [SerializeField] private SpriteRenderer render;
    public CharID CharID => charID;
    public void Equitment(CharID charID, Sprite imgWeapon) {
        this.charID = charID;
        this.render.sprite = imgWeapon;
    }

    public void Clear() {
        this.charID = CharID.None;
        this.render.sprite = null;
    }
}
