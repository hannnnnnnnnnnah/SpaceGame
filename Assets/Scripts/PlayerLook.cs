using UnityEngine;
using Unity.Netcode;
using Photon.Pun;
using UnityEditor;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] int sensitivity;

    private PhotonView photonView;
    [SerializeField] GameObject cam;

    public bool rotate = true;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        this.cam.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (photonView.IsMine)
            Rotate();
    }

    //Camera rotation stuff
    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.down * sensitivity * Time.fixedDeltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * sensitivity * Time.fixedDeltaTime);
        }
    }

}
