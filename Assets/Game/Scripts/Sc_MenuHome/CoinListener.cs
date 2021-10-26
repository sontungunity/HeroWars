using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Gafu.Base.Events;
using DG.Tweening;
using UnityEngine.UI;

public class CoinListener : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI txt_Amount;
    [SerializeField] private Button btn_Shop;
    private int cur_int;
    private int coinAmount => DataManager.Instance.PlayerData.Coin;
    private Tween tween;

    private void Awake() {
        btn_Shop.onClick.AddListener(() => { FrameManager.Instance.Push<ShopFrame>(); });
    }
    private void OnEnable() {
        EventDispatcher.AddListener<EventKey.CoinChange>(UpdateAmount);
    }

    private void OnDisable() {
        EventDispatcher.RemoveListener<EventKey.CoinChange>(UpdateAmount);
    }

    private void Start() {
        this.cur_int = coinAmount;
        txt_Amount.text = this.cur_int.ToString();
    }

    public void UpdateAmount(EventKey.CoinChange evt) {
        tween.CheckKillTween(true);
        tween = DOTween.To(() => cur_int,
            (value) => {
                txt_Amount.text = value.ToString();
            },
            coinAmount,
            0.5f
            ).OnComplete(() => {
                this.cur_int = coinAmount;
                txt_Amount.text = cur_int.ToString();
            });
    }
}
