using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Financials : MonoBehaviour
{
    public float money = 500;
    public float mineralCount;

    public UnityEvent MoneyChanged;
    public UnityEvent MineralCountChanged;

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
        GunShoot.instance.bullets += 5;
        GunShoot.instance.BulletsChanged.Invoke();
        money -= 50;
        MoneyChanged.Invoke();
    }

    public void AddMineralCount(float m)
    {
        mineralCount += m;
        MineralCountChanged.Invoke();
    }
}
