using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using Photon.Realtime;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI healthText;

    public static GameObject LocalPlayerInstance;

    private float healthSet;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        transform.SetParent(ShipMove.instance.transform);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(healthSet);
        }

        /*if (photonView.IsMine)
        {
            this.healthSet = ShipMove.instance.health;
            this.healthText.text = healthSet.ToString();
        }*/


        this.photonView.RPC("UpdateHealth", RpcTarget.All, ShipMove.instance.health);
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
        if(photonView.IsMine)
        {
            GunShoot.instance.Shoot();
        }
    }

    [PunRPC]
    public void UpdateHealth(float h)
    {
        healthSet = h;
        healthText.text = healthSet.ToString();
    }
}
