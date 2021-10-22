using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Gafu.Base.Events;

public class FloorEnemy : FloorBase {
    [SerializeField] private List<Transform> lstPositionChar;
    [SerializeField] private BoxCollider2D collder2D;
    [SerializeField] private GameObject glow;
    public List<CharBase> lstCharBase = new List<CharBase>();
    private void Start() {

    }

    public override void Show(FloorData fData) {
        SetUpDefault();
        for(int i = 0; i < fData.LstCharData.Count(); i++) {
            var charData = fData.LstCharData.ElementAt(i);
            var character = DataManager.Instance.GetCharByCharID(charData.CharID).Spawn(transform);
            character.transform.position = lstPositionChar[i].position;
            character.Show(charData.Power);
            lstCharBase.Add(character);
        }
    }

    public override void SetUpDefault() {
        collder2D.enabled = true;
        glow.SetActive(false);
    }

    public override void HeroOver(bool over) {
        glow.SetActive(over);
    }

    public override void HeroComeIn() {
        collder2D.enabled = false;
    }

    public override void HeroComeOut() {
        collder2D.enabled = true;
    }

    private void OnMouseEnter() {
        Debug.Log("Mouser_Enter");
        glow.SetActive(true);
        GamePlayManager.Instance.Hero.Cur_FloorOver = this;
    }

    private void OnMouseExit() {
        Debug.Log("Mouser_Exit");
        glow.SetActive(false);
        GamePlayManager.Instance.Hero.Cur_FloorOver = null;
    }

    private void OnMouseUp() {
        glow.SetActive(false);
        GamePlayManager.Instance.Hero.HandleFloor(this);
    }
}
