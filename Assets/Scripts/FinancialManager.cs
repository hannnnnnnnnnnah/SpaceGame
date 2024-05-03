using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinancialManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mineralText;
    [SerializeField] GameObject brokeText;

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
        if (Financials.instance.money > 0)
        {
            Financials.instance.BuyBullets();
            GunShoot.instance.ChangeBullets(5);
            brokeText.SetActive(false);
        }
        else
        {
            brokeText.SetActive(true);
        }
    }
}
