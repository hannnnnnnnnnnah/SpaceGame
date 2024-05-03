using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mineralText;

    private void Start()
    {
        Financials.instance.MineralCountChanged.AddListener(AddMineralCount);
    }

    public void AddMineralCount()
    {
        mineralText.text = Financials.instance.mineralCount.ToString();
    }

    public void SellMinerals()
    {
        Financials.instance.money += Financials.instance.mineralCount;
        Financials.instance.MoneyChanged.Invoke();
        Financials.instance.mineralCount = 0;

        mineralText.text = "0";
    }

    public void BuyBullets()
    {
        GunShoot.instance.ChangeBullets(5);
        Financials.instance.BuyBullets();
    }
}
