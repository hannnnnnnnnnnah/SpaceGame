using UnityEngine;
using Unity.Netcode;
using Photon.Pun;
using UnityEditor;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] int sensitivity;

    // cached transform of the target
    Transform playerTransform;

    public bool rotate = false;

    public void OnStartFollowing()
    {
        rotate = true;
    }

    private void FixedUpdate()
    {
        if (rotate)
            Rotate();
        else
            return; 
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
