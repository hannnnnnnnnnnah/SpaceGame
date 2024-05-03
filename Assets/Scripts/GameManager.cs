using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform[] spawnPositions;
    //public Color[] roleColors;
    public static GameManager instance;
    RoleManager roleManager => RoleManager.instance;

    Vector3 spawnSet;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        int playerID = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        spawnSet = spawnPositions[playerID].position;
        GameObject player = PhotonNetwork.Instantiate(this.playerPrefab.name, spawnSet, Quaternion.identity, 0);
        //player.GetComponent<MeshRenderer>().material.color = roleColors[playerID];
        if (playerID == 0)
        {
            roleManager.captain = true;
        }
        if (playerID == 1)
        {
            roleManager.combat = true;
        }
        if (playerID == 2)
        {
            roleManager.financial = true;
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
    public void LoseGame()
    {
        PhotonNetwork.LoadLevel("Lose");
    }
    public void WinGame()
    {
        PhotonNetwork.LoadLevel("Win");
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
            //LoadArena();
        }
    }

    public override void OnPlayerLeftRoom(Player other)
    {

        if (PhotonNetwork.IsMasterClient)
        {
            //LoadArena();
        }
    }
}
