using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine.Networking;
using UnityEngine;

public class UIManager : NetworkBehaviour
{
    [SerializeField] TextMeshProUGUI debugText = null;
    [SerializeField] GameObject LobbyUI;
    [SerializeField] Camera LobbyCam;

    public GameObject PlayerPrefab;
    private GameObject PlayerInstance;
    private NetworkObject PlayerNetworkObject;
    public Transform[] spawnPositions;

    public override void OnNetworkSpawn()
    {
        //enabled = IsServer;
        //if (!enabled || PlayerPrefab == null)
        //{
        //    return;
        //}

        PlayerInstance = Instantiate(PlayerPrefab);

        int connections = NetworkManager.Singleton.ConnectedClients.Count-1;

        PlayerInstance.transform.position = spawnPositions[connections].position;
        PlayerInstance.transform.rotation = transform.rotation;

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
