using Gafu.InGame.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameManager : Singleton<FrameManager>
{
    [SerializeField] private FrameBase firstFrame;
    [SerializeField] private List<FrameBase> lstFrameCollectes;
    private List<FrameBase> lstFrameReleases;

    private void Awake() {
        lstFrameReleases = new List<FrameBase>();
    }

    private void Start() {
        FrameBase instance = Instantiate(firstFrame, transform);
        instance.Init(this);
        instance.Show();
        lstFrameReleases.Add(instance);
    }

    public F Push<F>(Action<F> pushOption = null, Action onCompleted = null) where F: FrameBase {
        F frame = GetFrame<F>();
        if(frame) {
            pushOption?.Invoke(frame);
            frame.Show(onCompleted);
        }
        return null;
    }

    public F GetFrame<F> () where F : FrameBase {
        foreach(FrameBase frame in lstFrameReleases) {
            if(frame is F instance ) {
                return instance;
            }
        }

        foreach(FrameBase frame in lstFrameCollectes) {
            if(frame is F target) {
                F instance = Instantiate(target, transform);
                instance.Init(this);
                lstFrameReleases.Add(instance);
                return instance;
            }
        }
        return null;
    }
}
