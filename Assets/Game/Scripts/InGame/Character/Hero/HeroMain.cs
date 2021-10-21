using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMain : CharBase
{
    [SerializeField] private FloorBase floor;
    [SerializeField] private HeroTourch hr_Tourch;
    private void Awake()
    {
        hr_Tourch.Init(this);
    }

    #region AffterTourch
    public void AffterTourch()
    {
        floor.SetUpHeroPosition(this);
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TriggerFloor");
        FloorBase floor = collision.GetComponent<FloorBase>();
        if (floor!=null)
        {
            this.floor = floor;
        }
    }
}
