using Photon.Pun;
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
            ShipMove.instance.ChangeHealth(ShipMove.instance.health--);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
