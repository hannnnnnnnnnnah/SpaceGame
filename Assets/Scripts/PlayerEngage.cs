using UnityEngine;
using Unity.Netcode;

public class PlayerEngage : NetworkBehaviour
{
    [SerializeField] GameObject ship, bullet, gun;
    bool shipMove = false;
    public bool pilot, diplomat;
    float shipSpeed = 20;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        ship = GameManager.instance.Ship;
        bullet = GameManager.instance.Bullet;
    }

    private void FixedUpdate()
    {
        if (shipMove)
        {
            ship.transform.Translate(Vector3.back * Time.deltaTime * shipSpeed);
            //Debug.Log(ship.transform.position);
        }
    }

    //Captain methods

    public void ShipMove()
    {
        if(!shipMove)
            shipMove = true;
        else
            shipMove = false;
    }

    //Combat SP methods

    public void Shoot()
    {
        NetworkBehaviour.Instantiate(bullet, gun.transform.position, gun.transform.rotation);
    }

    //Diplomat methods

    public void Yes()
    {

    }

    public void No()
    {

    }
}
