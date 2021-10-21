using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerCS : MonoBehaviour {
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private FloorBase prefFloor;
    [SerializeField] private float plusHight;
    [SerializeField] private List<FloorBase> lstPrefFloor;
    private float hightFloor;

    //InputData
    private List<FloorData> lstFloorData;
    private void Awake() {
        hightFloor = prefFloor.GetComponent<SpriteRenderer>().bounds.size.y;
    }
    private void Init() {

    }

    public void Show(params FloorData[] arryFloor) {
        lstFloorData = arryFloor.ToList();
        render.size += new Vector2(0,arryFloor.Length*hightFloor);
        for(int i = 0; i < lstFloorData.Count; i++) {
            FloorBase floor = prefFloor.Spawn(transform);
            floor.transform.localPosition = new Vector2(0, plusHight + i * hightFloor);
            floor.Show(lstFloorData[i]);
        }
    }


}
