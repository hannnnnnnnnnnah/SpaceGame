using Photon.Pun;
using Photon.Pun.Demo.Asteroids;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GunShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    public float bullets = 10;

    public UnityEvent BulletsChanged;

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

        ChangeBullets(-1);
        //bullets--;
        //BulletsChanged.Invoke();
        //AudioManager.Instance.OnShoot();
    }

    public void ChangeBullets(float b)
    {
        bullets += b;
        BulletsChanged.Invoke();
    }
}
