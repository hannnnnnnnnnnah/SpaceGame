using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Diagnostics;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public float Health = 3f;
    public static GameObject LocalPlayerInstance;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        PlayerLook _camera = this.gameObject.GetComponent<PlayerLook>();

        if (_camera != null)
        {
            if (photonView.IsMine)
            {
                _camera.OnStartFollowing();
            }
        }
        else
        {
            print("error");
        }
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
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(Health);
            stream.SendNext(transform.position);
        }
        else
        {
            // Network player, receive data
            this.Health = (float)stream.ReceiveNext();
            this.transform.position = (Vector3)stream.ReceiveNext();
        }
    }

    public void DecreaseHealth()
    {
        Health--;
    }


}
