using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gafu.Base.Events;

public static class EventKey
{
    public struct ItemChange : IEventArgs
    {
        public ItemID ID;
        public int CurAmount;
        public int ChangeAmount;

        public ItemChange(ItemID ID, int CurAmount, int ChangeAmount)
        {
            this.ID = ID;
            this.CurAmount = CurAmount;
            this.ChangeAmount = ChangeAmount;
        }
    }

    public struct LoadFinal : IEventArgs
    {

    }
}
