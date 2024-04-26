using Photon.Pun;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10;
    float lifespan = 1.5f;

    private void Start()
    {
        StartCoroutine(KillSelf());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed);
    }

    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(lifespan);
        PhotonNetwork.Destroy(gameObject);
    }
}
