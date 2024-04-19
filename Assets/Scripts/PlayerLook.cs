using UnityEngine;
using Unity.Netcode;

public class PlayerLook : NetworkBehaviour
{
    [SerializeField] int minAngle, maxAngle, sensitivity;
    private Vector3 camRotation;

    public bool rotate = true;
    public Camera cam;

    private void FixedUpdate()
    {
        Rotate();
    }

    //Camera rotation stuff
    private void Rotate()
    {
        cam.transform.localEulerAngles = camRotation;

        if (rotate)
        {
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

}
