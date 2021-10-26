using Gafu.InGame.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using System;
using Gafu.Base.Events;

public class GamePlayManager : Singleton<GamePlayManager> {
    [SerializeField] private TowerCS towerHero;
    [SerializeField] private TowerCS towerEnemy;
    [SerializeField] private CameraInGame camInGame;
    [SerializeField] private HeroMain hero;
    public HeroMain Hero {
        get {
            return this.hero;
        }
        set {
            if(this.hero != null) {
                hero.Recycle();
            }
            this.hero = value;
        }
    }


    public int level;
    private LevelData levelData;
    public CharID IdCharCodition;


    private void Start() {
        PlayGame();
    }

    public void PlayGame() {
        SetUpDefault();
        FrameManager.Instance.Push<GamePanel>();
        //Load data
        if(GameManager.Instance != null) {
            level = DataManager.Instance.PlayerData.Level;
        }
        levelData = DataManager.Instance.GetLevelDataByLevel(level);
        GetQuestLevelData(levelData);


        //Setup 2 tower
        towerHero.Show(levelData.FloorHero);
        towerEnemy.Show(levelData.LstFloorData.ToArray());
        towerEnemy.SetCallBackRemoveFloor(() => {
            towerHero.Add();
        });
    }

    public void GetQuestLevelData(LevelData levelData) {
        foreach(var floor in levelData.LstFloorData) {
            foreach(var charB in floor.LstCharData) {
                if(charB.GetCharPrefByCharData() is CharCodition charCodition) {
                    IdCharCodition = charB.CharID;
                    //FrameManager.Instance.GetFrame<GamePanel>().AffterLoadLevel(level,IdCharCodition);
                    return;
                }
            }
        }
        IdCharCodition = CharID.E_NORMAL;
        //FrameManager.Instance.GetFrame<GamePanel>().AffterLoadLevel(level, IdCharCodition);
    }

    public bool CheckWin() {
        bool result = towerEnemy.LstFloor.Count == 1;
        if(result) {
            SetUpWin();
        }
        return result;
    }

    private void SetUpDefault() {
        camInGame.SetupDefault();
    }

    public void SetUpWin() {
        DataManager.Instance.PlayerData.PassLevel(level);
        hero.Win();
        camInGame.Room(hero.transform);
        FrameManager.Instance.GetFrame<GamePanel>().Hide();
        FrameManager.Instance.Push<ResultPanel>((frame) => frame.Show(true));
    }

    public void SetUpLoser() {
        hero.Loser();
        camInGame.Room(hero.transform);
        FrameManager.Instance.GetFrame<GamePanel>().Hide();
        FrameManager.Instance.Push<ResultPanel>((frame) => frame.Show(false));
    }

    public void Replay() {
        SetUpDefault();
        FrameManager.Instance.Push<GamePanel>();
        towerHero.Show(levelData.FloorHero);
        towerEnemy.Show(levelData.LstFloorData.ToArray());
    }

    public void SkipLevel() {
        DataManager.Instance.PlayerData.PassLevel(level);
        NextLevel();
    }

    public void NextLevel() {
        GamePlayManager.Instance.level++;
        GamePlayManager.Instance.PlayGame();
    }
}
