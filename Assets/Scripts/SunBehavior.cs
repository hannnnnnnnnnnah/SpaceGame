using Photon.Pun;
using System;
using UnityEngine;

public class SunBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ship"))
        {
            print("collided");
            GameManager.instance.WinGame();
        }
    }
}
