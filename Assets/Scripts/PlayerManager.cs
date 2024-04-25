using Photon.Pun;
using Photon.Pun.Demo.PunBasics;
using System.Diagnostics;
using UnityEngine;

public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public float Health = 3f;
    public static GameObject LocalPlayerInstance;

    //Values that will be synced over network
    Quaternion latestRot;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        PlayerLook playerLook = this.gameObject.GetComponent<PlayerLook>();

        if (playerLook != null)
        {
            if (photonView.IsMine)
            {
                playerLook.OnStartFollowing();
            }
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

        if (!photonView.IsMine)
        {
            //Update remote player (smooth this, this looks good, at the cost of some accuracy)
            //photonView.transform.rotation = Quaternion.Lerp(transform.rotation, latestRot, Time.deltaTime * 5);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //We own this player: send the others our data
            //stream.SendNext(transform.rotation);
        }
        else
        {
            //Network player, receive data
            //latestRot = (Quaternion)stream.ReceiveNext();
        }
    }

    public void DecreaseHealth()
    {
        Health--;
    }
}
