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
    private GameObject PlayerNetworkObject;


    public override void OnNetworkSpawn()
    {
        
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
