using UnityEngine;
using Unity.Netcode;
using Photon.Pun;

public class PlayerEngage : MonoBehaviourPun
{
    [SerializeField] GameObject Captain, Combat, bullet, gun, ship;

    bool shipMove = false;
    float shipSpeed = 20;

    private void Start()
    {
        if (RoleManager.instance.captain)
            this.Captain.SetActive(true);

        if (RoleManager.instance.combat)
            this.Combat.SetActive(true);
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
        if (photonView.IsMine)
        {
            if (!shipMove)
                shipMove = true;
            else
                shipMove = false;
        }
    }

    //Combat SP methods

    public void Shoot()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate(this.bullet.name, gun.transform.position, gun.transform.rotation);
        }
    }

    //Diplomat methods

    public void Yes()
    {

    }

    public void No()
    {

    }
}
