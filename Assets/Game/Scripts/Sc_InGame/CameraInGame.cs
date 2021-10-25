using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraInGame : MonoBehaviour {
    [SerializeField] private Camera cam;
    [SerializeField] private float orthoSizeRoom = 3f;
    [SerializeField] private float timeTarget = 0.75f;
    private Tween tween_Move;
    private Tween tween_Size;
    public void Room(Transform target, float size, float timeTarget = 1f) {
        Vector3 posCameraAfter = target.transform.position;
        posCameraAfter.z = cam.transform.position.z;
        tween_Move = cam.transform.DOMove(posCameraAfter, timeTarget);
        tween_Size = cam.DOOrthoSize(size, timeTarget);
    }

    public void Room(Transform target) {
        Room(target, orthoSizeRoom, timeTarget);
    }

    private void OnDisable() {
        tween_Move.CheckKillTween();
        tween_Size.CheckKillTween();
    }

    private void OnDestroy() {
        tween_Move.CheckKillTween();
        tween_Size.CheckKillTween();
    }
}
