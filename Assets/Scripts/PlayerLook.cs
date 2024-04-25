using UnityEngine;
using Unity.Netcode;
using Photon.Pun;

public class PlayerLook : MonoBehaviourPun
{
    [SerializeField] int minAngle, maxAngle, sensitivity;
    private Vector3 camRotation;

    public bool rotate = false;
    public Camera cam;

    public void OnStartFollowing()
    {
        rotate = true;
    }

    private void FixedUpdate()
    {
        if(rotate)
            Rotate();
    }

    //Camera rotation stuff
    private void Rotate()
    {
        cam.transform.localEulerAngles = camRotation;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * sensitivity * Time.fixedDeltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * sensitivity * Time.fixedDeltaTime);
        }
    }

}
