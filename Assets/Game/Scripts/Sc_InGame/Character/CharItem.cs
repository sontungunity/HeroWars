using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharItem : CharBase
{
    public override void Show(int power = 0, FloorBase floor = null) {
        SetUpDefault();
        this.power = power;
        this.Floor = floor;
        //txtPower.Show(power);
    }

    public void GetItem() {
        transform.localScale = Vector3.zero;
        this.Recycle();
    }

    public override void SetUpDefault() {
        base.SetUpDefault();
        transform.localScale = Vector3.one;

    }
}
