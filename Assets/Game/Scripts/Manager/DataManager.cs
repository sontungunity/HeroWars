using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager> {
    private const string LEVELDATA_PATH = "LevelData/Level_";
    [SerializeField] private List<CharBase> lstCharBase;
    
    private void Start() {

    }

    public LevelData GetLevelDataByLevel(int level) {
        LevelData result = Resources.Load<LevelData>(LEVELDATA_PATH + level.ToString());
        if(result == null) {
            Resources.Load<LevelData>(LEVELDATA_PATH + "0");
        }
        return result;
    }

    public CharBase GetCharByCharID(CharID id) {
        CharBase result = null;
        foreach(CharBase character in lstCharBase) {
            if(character.CharID == id) {
                result = character;
            }
        }
        if(result == null) {
            result = GetCharByCharID(CharID.E_NORMAL);
        }
        return result;
    }


    public void SaveData() {

    }

    public void LoadData() {

    }
}
