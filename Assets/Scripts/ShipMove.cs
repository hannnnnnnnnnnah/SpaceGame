using Photon.Pun;
using UnityEngine;

public class ShipMove : MonoBehaviour
{
    public bool shipMove = false;
    float shipSpeed = 20;
    public float health = 5;

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
            transform.Translate(Vector3.back * Time.deltaTime * shipSpeed);
    }

    
    public void ChangeHealth(float h)
    {
        health = h;
        Debug.Log("health");
    }
}
