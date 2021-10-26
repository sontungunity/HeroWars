using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmful : CharBase
{
    public void Harm(HeroMain heroMain,Action callBack) {
        transform.localScale = Vector3.zero;
        heroMain.AddPower(Power);
        callBack?.Invoke();
    }

    public override void SetUpDefault() {
        base.SetUpDefault();
        transform.localScale = Vector3.one;
    }
}
