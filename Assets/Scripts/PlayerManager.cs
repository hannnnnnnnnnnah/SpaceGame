using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public float Health = 3f;
    public static GameObject LocalPlayerInstance;

    string test = "";
    string netTest;

    private void Awake()
    {
        //if (photonView.IsMine)
        //{
        //    PlayerManager.LocalPlayerInstance = this.gameObject;
        //}

        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        transform.SetParent(ShipMove.instance.transform);
    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if (Health <= 0f)
            {
                GameManager.instance.LeaveRoom();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(netTest);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            test = "change";
        }

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //We own this player: send the others our data
            stream.SendNext(test);
        }
        else
        {
            //Network player, receive data
            this.netTest = (string)stream.ReceiveNext();
        }
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
