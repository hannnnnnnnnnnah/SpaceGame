using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Financials : MonoBehaviourPunCallbacks
{
    public float money = 500;
    public float mineralCount;

    public UnityEvent MoneyChanged;
    public UnityEvent MineralCountChanged;
    public UnityEvent BulletsBought;

    public static Financials instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void BuyBullets()
    {
        money -= 50;
        MoneyChanged.Invoke();
        BulletsBought.Invoke();
    }

    public void AddMineralCount(float m)
    {
        mineralCount += m;
        MineralCountChanged.Invoke();
    }
}
