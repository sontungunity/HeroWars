using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class Extentions {
    public static void CheckKillTween(this Tween tween, bool OnComplate = false) {
        if(tween != null) {
            tween.Kill(OnComplate);
        }
    }

    public static CharBase GetCharPrefByCharID(this CharID id) {
        return DataManager.Instance.GetCharByCharID(id);
    }

    public static CharBase GetCharPrefByCharData(this CharData charData) {
        return DataManager.Instance.GetCharByCharID(charData.CharID);
    }
}

public enum CharID {
    None,
    HERO,
    E_NORMAL,
    WOONDEN_POLES, // Cột gỗ
    PRICES,
    SWORD,  // Kiếm
    KNIFE,  // Dao
    WOLF,   //Sói
    IRON_MACE, // chùy sắt
    E_ARCHERY, //Cung
    TURTLE,
    KEY,
    CHEST// Rùa
}

public enum ItemID {

}
