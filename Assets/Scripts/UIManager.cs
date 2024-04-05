using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UIManager : NetworkBehaviour
{
    [SerializeField] TextMeshProUGUI debugText = null;
    [SerializeField] GameObject LobbyUI;
    [SerializeField] Camera LobbyCam;

    public GameObject PlayerPrefab;
    private GameObject PlayerInstance;
    private NetworkObject PlayerNetworkObject;
    public Vector3 PlayerSpawnPosition;

    public override void OnNetworkSpawn()
    {
        //enabled = IsServer;
        //if (!enabled || PlayerPrefab == null)
        //{
        //    return;
        //}

        PlayerInstance = Instantiate(PlayerPrefab);

        PlayerInstance.transform.position = PlayerSpawnPosition;
        PlayerInstance.transform.rotation = transform.rotation;

        print("ideal pos is " + PlayerSpawnPosition);
        print("actual pos is " + PlayerInstance.transform.position);

        PlayerNetworkObject = PlayerInstance.GetComponent<NetworkObject>();
        PlayerNetworkObject.Spawn();
    }

    public void StartHost()
    {
        if (NetworkManager.Singleton.StartHost())
        {
            //LobbyUI.SetActive(false);
            //LobbyCam.enabled = false;
            debugText.text = "Host started";
        }
        else
        {
            debugText.text = "Host failed to Start";
        }
    }

    public void StartServer()
    {
        if (NetworkManager.Singleton.StartServer())
        {
            debugText.text = "Server started";
        }
        else
        {
            debugText.text = "Server failed to Start";
        }
    }

    public void StartClient()
    {
        if (NetworkManager.Singleton.StartClient())
        {
            //LobbyUI.SetActive(false);
            //LobbyCam.enabled = false;
            debugText.text = "Client started";
        }
        else
        {
            debugText.text = "Client failed to Start";
        }
    }
}
