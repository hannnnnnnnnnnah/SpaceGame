using Photon.Pun;
using System;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    public float speed = 20;
    public float trailLifetime;
    TrailRenderer trailRenderer => GetComponent<TrailRenderer>();

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

    private void FixedUpdate()
    {
        if (trailRenderer != null)
        {
            trailRenderer.time = trailLifetime;
        }

        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
