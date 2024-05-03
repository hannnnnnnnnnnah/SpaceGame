using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Collections;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI healthText, bulletText, moneyText;
    public Material[] roleColors;

    [SerializeField] GameObject body, button, coolText;
    public static GameObject LocalPlayerInstance;

    private float healthSet, bulletSet, moneySet;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        transform.SetParent(ShipMove.instance.transform);
        ShipMove.instance.HealthChanged.AddListener(HealthUpdater);
        GunShoot.instance.BulletsChanged.AddListener(BulletUpdater);
        Financials.instance.MoneyChanged.AddListener(MoneyUpdater);
        Financials.instance.BulletsBought.AddListener(BulletUpdater);

        int playerID = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        body.GetComponent<SkinnedMeshRenderer>().material = roleColors[playerID];
    }

    public void MoveShip()
    {
        if (photonView.IsMine)
        {
            if (!ShipMove.instance.shipMove)
                ShipMove.instance.shipMove = true;
            else
                ShipMove.instance.shipMove = false;
        }
    }

    public void Shoot()
    {
        if (photonView.IsMine && GunShoot.instance.bullets > 0)
        {
            GunShoot.instance.Shoot();
            coolText.SetActive(false);
            //button.SetActive(true);
        }
        else
            BulletsOut();
    }

    public void BulletsOut()
    {
        //button.SetActive(false);
        coolText.SetActive(true);
    }

    void BulletUpdater()
    {
        photonView.RPC("UpdateBullets", RpcTarget.All, GunShoot.instance.bullets);
    }

    void MoneyUpdater()
    {
        photonView.RPC("UpdateMoney", RpcTarget.All, Financials.instance.money);
    }

    void HealthUpdater()
    {
        photonView.RPC("UpdateHealth", RpcTarget.All, ShipMove.instance.health);
    }

    [PunRPC]
    public void UpdateHealth(float h)
    {
        healthSet = h;
        healthText.text = healthSet.ToString();
    }

    [PunRPC]
    public void UpdateBullets(float b)
    {
        bulletSet = b;
        bulletText.text = bulletSet.ToString();
    }

    [PunRPC]
    public void UpdateMoney(float m)
    {
        moneySet = m;
        moneyText.text = moneySet.ToString();
    }
}
