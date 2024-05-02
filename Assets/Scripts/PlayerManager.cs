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
    [SerializeField] TextMeshProUGUI healthText;
    public Material[] roleColors;

    [SerializeField] GameObject body, button, coolText;
    public static GameObject LocalPlayerInstance;

    private float healthSet;

    float limit, cooldown = 5;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        transform.SetParent(ShipMove.instance.transform);
        ShipMove.instance.HealthChanged.AddListener(UpdateVariables);

        int playerID = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        //this.body.GetComponent<MeshRenderer>().material = roleColors[playerID];
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
        if (photonView.IsMine && limit > 0)
        {
            GunShoot.instance.Shoot(); 
            limit--;
        }
        else
            StartCoroutine(CoolingDown());
    }

    IEnumerator CoolingDown()
    {
        button.SetActive(false);
        coolText.SetActive(true);
        yield return new WaitForSeconds(cooldown);
        button.SetActive(true);
        coolText.SetActive(false);
        limit = 5;
    }

    void UpdateVariables()
    {
        photonView.RPC("UpdateHealth", RpcTarget.All, ShipMove.instance.health);
    }

    [PunRPC]
    public void UpdateHealth(float h)
    {
        healthSet = h;
        healthText.text = healthSet.ToString();
    }
}
