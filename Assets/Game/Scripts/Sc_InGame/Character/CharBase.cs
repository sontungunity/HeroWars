using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharBase : MonoBehaviour {
    [SerializeField] private CharID charID;
    [SerializeField] private TextNumber txtPower;
    [SerializeField] private int power;
    public TextNumber TxtPower => txtPower;
    public CharID CharID => charID;
    public int Power => power;
    public FloorBase Floor;
    public virtual void Show(int power = 0, FloorBase floor = null) {
        this.power = power;
        this.Floor = floor;
        txtPower.Show(power);
        SetUpDefault();
    }

    public virtual void SetUpDefault() {

    }
}
