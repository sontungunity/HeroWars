using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroTourch : MonoBehaviour {

    private HeroMain hero;
    private List<FloorEnemy> lstFloorTrigger = new List<FloorEnemy>();
    public void Init(HeroMain hero) {
        this.hero = hero;
    }

    private bool isBeingHeld = false;
    // Update is called once per frame
    void Update() {
        if(isBeingHeld == true) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown() {
        if(Input.GetMouseButtonDown(0)) {
            isBeingHeld = true;
            lstFloorTrigger.Clear();
        }

    }

    private void OnMouseUp() {
        if(isBeingHeld) {
            isBeingHeld = false;
            if(lstFloorTrigger!=null && lstFloorTrigger.Count > 0) {
                hero.AffterTourch(lstFloorTrigger.Last());
            } else {
                hero.AffterTourch(null);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        FloorEnemy floorE = collision.GetComponent<FloorEnemy>();
        if(floorE != null) {
            foreach(var fl in lstFloorTrigger) {
                fl.Glow.SetActive(false);
            }
            floorE.Glow.SetActive(true);
            lstFloorTrigger.Add(floorE);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        FloorEnemy floorE = collision.GetComponent<FloorEnemy>();
        if(floorE != null) {
            floorE.Glow.SetActive(false);
            lstFloorTrigger.Remove(floorE);
            foreach(var fl in lstFloorTrigger) {
                fl.Glow.SetActive(false);
            }
            if(lstFloorTrigger != null && lstFloorTrigger.Count > 0) {
                lstFloorTrigger.Last().Glow.SetActive(true);
            }
        }
    }
}
