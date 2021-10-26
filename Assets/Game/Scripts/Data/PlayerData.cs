using Gafu.Base.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int Level = 0;
    public int Coin = 0;
    public bool UnLockSkin = false;
    public bool RemoveAds = false;

    public void AddCoin(int value) {
        Coin += value;
        EventDispatcher.Dispatch<EventKey.CoinChange>(new EventKey.CoinChange());
    }

    public void PassLevel(int level) {
        if(level >= this.Level) {
            this.Level = level+1;
        }
    }
}
