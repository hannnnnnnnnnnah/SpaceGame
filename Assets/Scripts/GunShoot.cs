using Photon.Pun;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public static GunShoot instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Shoot()
    {
        PhotonNetwork.Instantiate(this.bullet.name, transform.position, transform.rotation);
    }
}
