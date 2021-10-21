using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InGameManager : Singleton<InGameManager>
{
    [SerializeField] private TowerCS towerHero;
    [SerializeField] private TowerCS towerEnemy;
    public int level;
    private LevelData levelData;

    private void Start()
    {
        if(GameManager.Instance!=null) {
            level = GameManager.Instance.Cur_Level;
        } 
        levelData = DataManager.Instance.GetLevelDataByLevel(level);
        towerHero.Show(levelData.FloorHero);
        towerEnemy.Show(levelData.LstFloorData.ToArray());
    }
}
