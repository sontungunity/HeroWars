using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCS : CharCodition
{
    public override bool GetWin(HeroMain heroMain, Action callback = null) {
        if(heroMain.Exist(CharID.KEY)) {
            this.Recycle();
            return true;
        } else {
            return false;
        }
        
    }
}
