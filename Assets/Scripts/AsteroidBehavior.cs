using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            PhotonNetwork.Destroy(gameObject);
        }

        if (other.CompareTag("Ship"))
        {
            other.GetComponent<ShipMove>().health--;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
