using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTourch : MonoBehaviour
{
    private HeroMain hero;
    public void Init(HeroMain hero)
    {
        this.hero = hero;
    }

    private bool isBeingHeld = false;
    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.position = new Vector3(mousePos.x,mousePos.y,0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isBeingHeld = true;
        }

    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
        hero.AffterTourch();
    }
}
