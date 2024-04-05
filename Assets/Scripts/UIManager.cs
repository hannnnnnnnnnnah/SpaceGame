using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UIManager : NetworkBehaviour
{
    [SerializeField] TextMeshProUGUI debugText = null;
    [SerializeField] GameObject LobbyUI;
    [SerializeField] NetworkObject FA, Diplomat;
    [SerializeField] Camera LobbyCam;

    bool spawnFA, spawnDiplomat = false;

    public void PickPlayer()
    {
        spawnFA = true;
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

    public override void OnNetworkSpawn()
    {
        if(spawnFA)
            FA.SpawnAsPlayerObject(OwnerClientId);

        if(spawnDiplomat)
            Diplomat.SpawnAsPlayerObject(OwnerClientId);
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
            spawnDiplomat = true;
        }
        else
        {
            debugText.text = "Client failed to Start";
        }
    }
}
