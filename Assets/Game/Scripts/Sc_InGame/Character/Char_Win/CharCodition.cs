using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCodition : CharBase
{
    [SerializeField] private string description;

    private string Description => description;

    public override void Show(int power = 0, FloorBase floor = null) {
        SetUpDefault();
        this.power = power;
        this.Floor = floor;
        //txtPower.Show(power);
    }

    public void GetWin(HeroMain heroMain,Action callback) {
        
    }
}
