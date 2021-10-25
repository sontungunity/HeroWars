using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameBase : MonoBehaviour
{
    [Header("[Events]")]
    [SerializeField] private Action<FrameBase> onShowed;
    [SerializeField] private Action<FrameBase> onHidden;

    [Header("[Animation]")]
    [SerializeField] protected UIAnimation showAnimation;
    [SerializeField] protected UIAnimation hideAnimation;

    private FrameManager uiManager;
    public void Init(FrameManager uiManager) {
        this.uiManager = uiManager;
    }

    public void Show(Action onCompleted = null) {
        gameObject.SetActive(true);
        OnShow();
        onCompleted?.Invoke();
    }

    public virtual void OnShow() {

    }



}
