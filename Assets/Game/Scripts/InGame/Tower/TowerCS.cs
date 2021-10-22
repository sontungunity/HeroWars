using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerCS : MonoBehaviour {
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private FloorBase prefFloor;
    [SerializeField] private float startHight;
    [SerializeField] private float space;
    [SerializeField] private List<FloorBase> lstPrefFloor;
    private float HightFloor => prefFloor.HightFloor+space;

    //InputData
    private List<FloorData> lstFloorData;
    private void Init() {

    }

    public void Show(params FloorData[] arryFloor) {
        lstFloorData = arryFloor.ToList();
        render.size += new Vector2(0,arryFloor.Length* HightFloor);
        for(int i = 0; i < lstFloorData.Count; i++) {
            FloorBase floor = prefFloor.Spawn(transform);
            floor.transform.localPosition = new Vector2(0, startHight + i * HightFloor);
            floor.Show(lstFloorData[i]);
        }
    }


}
