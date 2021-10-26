using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gafu.Base.Events;

public static class EventKey {
    //public struct ItemChange : IEventArgs {
    //    public ItemID ID;
    //    public int CurAmount;
    //    public int ChangeAmount;

    //    public ItemChange(ItemID ID, int CurAmount, int ChangeAmount) {
    //        this.ID = ID;
    //        this.CurAmount = CurAmount;
    //        this.ChangeAmount = ChangeAmount;
    //    }
    //}

    public struct LoadFinal : IEventArgs {

    }

    public struct SelectFloor : IEventArgs{
        public FloorBase Floor;

        public SelectFloor(FloorBase floor) {
            this.Floor = floor;
        }
    }

    public struct CoinChange : IEventArgs {

    }

    public struct LoadLevel : IEventArgs {
        public int level;
        public CharID charCodition;

        public LoadLevel(int level, CharID charCodition) {
            this.level = level;
            this.charCodition = charCodition;
        }
    }
}
