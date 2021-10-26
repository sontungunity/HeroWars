using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClose : MonoBehaviour {
    [SerializeField] private Button btn_Close;
    [SerializeField] private FrameBase frame;

    private void Awake() {
        btn_Close.onClick.AddListener(CloseFrame);
    }

    private void CloseFrame() {
        if(frame!=null) {
            frame.Hide();
        }
    }
}
