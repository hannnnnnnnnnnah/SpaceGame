using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
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
            Debug.Log(ShipMove.instance.health);
        }

        /*if (photonView.IsMine)
        {
            this.healthSet = ShipMove.instance.health;
            this.healthText.text = healthSet.ToString();
        }*/
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /*
        if (stream.IsWriting)
        {
            //Send data
            stream.SendNext(healthSet);
        }
        else 
        {
            // Network player, receive data
            this.healthSet = (float)stream.ReceiveNext();
        }*/
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
}
