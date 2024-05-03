using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class ShipMove : MonoBehaviour
{
    public bool shipMove = false;
    float shipSpeed = 20;
    public float health = 5;

    public UnityEvent HealthChanged;

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

    
    public void ChangeHealth()
    {
        health--;
        HealthChanged.Invoke();
        if (health <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }
}
