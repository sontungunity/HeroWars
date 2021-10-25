using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField] private TowerCS towerHero;
    [SerializeField] private TowerCS towerEnemy;
    [SerializeField] private CameraInGame camInGame;
    [SerializeField] private HeroMain hero;
    public HeroMain Hero {
        get {
            return this.hero;
        }
        set {
            if(this.hero!=null) {
                hero.Recycle();
            }
            this.hero = value;
        }
    }

    public void Replay() {
        towerHero.Show(levelData.FloorHero);
        towerEnemy.Show(levelData.LstFloorData.ToArray());
    }

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
        towerEnemy.SetCallBackRemoveFloor(()=> {
            towerHero.Add(); 
        });
    }

    public bool CheckWin() {
        bool result = towerEnemy.LstFloor.Count == 1;
        if(result) {
            SetUpWin();
        }
        return result;
    }

    private void SetUpWin() {
        hero.Win();
        camInGame.Room(hero.transform);
    }
}
