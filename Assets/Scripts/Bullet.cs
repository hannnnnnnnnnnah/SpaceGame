using System.Collections;
using Unity.Netcode;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    float speed = 10;
    float lifespan = 1.5f;

    private void Start()
    {
        //StartCoroutine(KillSelf());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * speed);
    }

    IEnumerator KillSelf()
    {
        yield return new WaitForSeconds(lifespan);
        NetworkBehaviour.Destroy(gameObject);
    }
}
