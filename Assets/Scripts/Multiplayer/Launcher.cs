using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Launcher : MonoBehaviourPunCallbacks
{
    public InputField createInput, joinInput;
    string gameVersion = "1";
    bool isConnecting;

    [SerializeField] int maxPlayersPerRoom = 4;

    void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }
    }

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinRoom("Main");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = false;
        roomOptions.MaxPlayers = maxPlayersPerRoom;

        if (PhotonNetwork.CountOfPlayersInRooms == 0)
            PhotonNetwork.CreateRoom("Main", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Main");
    }

    public void Connect()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRoom("Main");
            isConnecting = false;
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();

            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        Debug.Log(PhotonNetwork.CountOfRooms);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }
}
