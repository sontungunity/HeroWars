using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using DG.Tweening;

public class TowerCS : MonoBehaviour {
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private FloorBase prefFloor;
    [SerializeField] private float startHight;
    [SerializeField] private float space;
    [SerializeField] private List<FloorBase> lstFloor = new List<FloorBase>();
    [SerializeField] private float timeRemoveFloor = 0.5f;
    public List<FloorBase> LstFloor => lstFloor;
    private float HightFloor => prefFloor.HightFloor + space;
    private Action act_AddFloor;
    private Action act_RemoveFloor;
    //InputData
    private List<FloorData> lstFloorData;
    private Tween tween;
    [SerializeField] private Status status;
    public Status STT => status;
    private void Awake() {
        
    }
    private void Init() {

    }

    public void Show(params FloorData[] arryFloor) {
        lstFloor.Clear();
        lstFloorData = arryFloor.ToList();
        render.size += new Vector2(0, arryFloor.Length * HightFloor);
        for(int i = 0; i < lstFloorData.Count; i++) {
            FloorBase floor = prefFloor.Spawn(transform);
            floor.transform.localPosition = new Vector2(0, startHight + i * HightFloor);
            floor.Show(lstFloorData[i], this);
            lstFloor.Add(floor);
        }
        status = Status.IDLE;
    }

    public void SetCallBackRemoveFloor(Action callBack) {
        this.act_RemoveFloor = callBack;
    }

    public void Remove(FloorEnemy floorEnemy) {
        status = Status.BUILDING;
        bool flag_higher = false;
        foreach(var fl in lstFloor) {
            if(flag_higher) {
                fl.Move(-HightFloor, timeRemoveFloor);
            }
            if(fl.GetInstanceID() == floorEnemy.GetInstanceID()) {
                flag_higher = true;
            }
        }
        float hightTowerAfter = render.size.y - HightFloor;
        tween = DOTween.To(() => render.size.y,
            (value) => {
                render.size = new Vector2(render.size.x, value);
            },
            hightTowerAfter,
            timeRemoveFloor).OnComplete(() => {
                status = Status.IDLE;
                lstFloor.Remove(floorEnemy);
                floorEnemy.Recycle();
                act_RemoveFloor?.Invoke();
            });
    }

    public void Add(FloorData data = null) {
        status = Status.BUILDING;
        foreach(var fl in lstFloor) {
            fl.Move(HightFloor, timeRemoveFloor);
        }
        float hightTowerAfter = render.size.y + HightFloor;
        tween = DOTween.To(() => render.size.y,
            (value) => {
                render.size = new Vector2(render.size.x, value);
            },
            hightTowerAfter,
            timeRemoveFloor).OnComplete(() => {
                FloorBase floor = prefFloor.Spawn(transform);
                floor.transform.localPosition = new Vector2(0, startHight);
                floor.Show(data, this);
                lstFloor.Add(floor);
                status = Status.IDLE;
                act_AddFloor?.Invoke();
            });

    }

    public void ClearTower() {
        foreach(var floor in lstFloor) {
            floor.Clear();
        }
        lstFloor.Clear();
    }
    public enum Status {
        IDLE,
        BUILDING,
    }
}
