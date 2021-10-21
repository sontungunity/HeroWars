using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharBase : MonoBehaviour {
    [SerializeField] private CharID charID;
    [SerializeField] private TextMeshPro txtPower;

    [Header("Cur_Info")]
    [SerializeField]private int power;
    public CharID CharID => charID;
    public int Power => power;
    public virtual void Show(int power = 0) {
        this.power = power;
        txtPower.text = power.ToString();
    }
}
