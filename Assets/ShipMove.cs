using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public bool shipMove = false;
    float shipSpeed = 20;

    public static ShipMove instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (shipMove)
        {
            transform.Translate(Vector3.back * Time.deltaTime * shipSpeed);
            //Debug.Log(ship.transform.position);
        }
    }
}
