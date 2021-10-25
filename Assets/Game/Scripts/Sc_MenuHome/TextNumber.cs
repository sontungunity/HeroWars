using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System;

public class TextNumber : MonoBehaviour {
    [SerializeField] private TextMeshPro txtNumber;
    private int cur_int = 0;
    private Tween tween;
    public void Show(int number, bool smooth = false, float time = 0.5f, Action callback = null) {
        if(smooth) {
            tween.CheckKillTween(true);
            tween = DOTween.To(() => cur_int,
                (value) => {
                    txtNumber.text = value.ToString();
                },
                number,
                time
                ).OnComplete(()=> {
                    this.cur_int = number;
                    txtNumber.text = number.ToString();
                    callback?.Invoke();
                });
        } else {
            this.cur_int = number;
            txtNumber.text = number.ToString();
            callback?.Invoke();
        }
    }

    private void OnDisable() {
        tween.CheckKillTween();
    }

    private void OnDestroy() {
        tween.CheckKillTween();
    }

}
