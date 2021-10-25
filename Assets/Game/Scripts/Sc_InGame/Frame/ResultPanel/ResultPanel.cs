using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultPanel : FrameBase
{
    [Header("PAGE")]
    [SerializeField] private TextMeshProUGUI txt_Result;
    [SerializeField] private DisplayObjects obj_BtnStyle; // 0. Win, 1. Loser
    public void Show(bool result) {
        txt_Result.text = result ? "Win" : "Loser";
        obj_BtnStyle.Active(result ? 0 : 1);
    }
}
