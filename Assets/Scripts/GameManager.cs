using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab, spawn1, spawn2, spawn3, spawn4;
    public static GameManager instance;

    Vector3 spawnSet;
    List<Player> spawnList;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        if (RoleManager.instance.captain)
            spawnSet = spawn1.transform.position;

        if (RoleManager.instance.combat)
            spawnSet = spawn2.transform.position;

        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            PhotonNetwork.Instantiate(this.playerPrefab.name, spawnSet, Quaternion.identity, 0);

            //if (PlayerManager.LocalPlayerInstance == null)
            //{
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
            //    PhotonNetwork.Instantiate(this.playerPrefab.name, spawnSet, Quaternion.identity, 0);
            //}
        }
    }

    // Called when the local player left the room. We need to load the launcher scene.
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("StartRoom");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArena()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        PhotonNetwork.LoadLevel("Main");
    }

    public override void OnPlayerEnteredRoom(Player other)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("this is running");
            //PhotonNetwork.Instantiate(this.playerPrefab.name, spawnSet, Quaternion.identity, 0);
            LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {

        if (PhotonNetwork.IsMasterClient)
        {
            LoadArena();
        }
    }
}
