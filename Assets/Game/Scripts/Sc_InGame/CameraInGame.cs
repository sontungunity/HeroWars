using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraInGame : MonoBehaviour {
    [SerializeField] private Camera cam;
    [SerializeField] private float orthoSizeRoom = 3f;
    [SerializeField] private float timeTarget = 0.75f;
    private Vector3 root_Position;
    private float root_Size;
    private Tween tween_Move;
    private Tween tween_Size;

    private void Awake() {
        root_Position = transform.position;
        root_Size = cam.orthographicSize;
    }

    public void Room(Transform target, float size, float timeTarget = 1f) {
        Vector3 posCameraAfter = target.transform.position;
        posCameraAfter.z = cam.transform.position.z;
        tween_Move = cam.transform.DOMove(posCameraAfter, timeTarget);
        tween_Size = cam.DOOrthoSize(size, timeTarget);
    }

    public void Room(Transform target) {
        Room(target, orthoSizeRoom, timeTarget);
    }

    public void SetupDefault() {
        tween_Move.CheckKillTween();
        tween_Move = cam.transform.DOMove(root_Position,1f);
        tween_Size.CheckKillTween();
        tween_Size = cam.DOOrthoSize(root_Size, 1f);
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
