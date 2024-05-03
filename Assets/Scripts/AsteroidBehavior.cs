using Photon.Pun;
using System;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Financials.instance.AddMineralCount(50);
            PhotonNetwork.Destroy(gameObject);
        }

        if (other.CompareTag("Ship"))
        {
            ShipMove.instance.ChangeHealth();
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
