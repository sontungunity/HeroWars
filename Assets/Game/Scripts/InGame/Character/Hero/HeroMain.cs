using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMain : CharBase {
    [SerializeField] private HeroTourch hr_Tourch;
    public FloorBase Cur_FloorOver = default;
    public FloorBase Cur_Floor = default;
    private HeroStatus status;
    private void Awake() {
        hr_Tourch.Init(this);
    }

    private void Start() {
        status = HeroStatus.IDEL;
    }

    #region AffterTourch
    public void AffterTourch() {
        if(Cur_FloorOver==null) {
            Cur_Floor.SetUpHeroPosition(this);
        }
    }
    #endregion

    public void HandleFloor(FloorEnemy floorE) {
        Cur_Floor = floorE;
        Cur_Floor.SetUpHeroPosition(this);
        StartCoroutine(IEHanlderFloor(floorE));
    }

    IEnumerator IEHanlderFloor(FloorEnemy floorE) {
        status = HeroStatus.ACTION;
        foreach(var charG in floorE.lstCharBase) {
            float time = ActionByChar(charG);
            yield return new WaitForSeconds(time);
        }
        yield return null;
    }

    public float ActionByChar(CharBase charG) {
        return 0f;
    }

    public enum HeroStatus {
        IDEL,
        MOVE,
        ACTION,
        WIN,
        LOSER
    }

    public enum HeroAction {
        DAME,

    }
}
