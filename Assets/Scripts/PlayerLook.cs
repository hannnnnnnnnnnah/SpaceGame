using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

public class PlayerLook : NetworkBehaviour
{
    [SerializeField] int minAngle, maxAngle, sensitivity;
    private Vector3 camRotation;

    public bool rotate = true;
    public Camera cam;

    private void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

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
            transform.Rotate(Vector3.up * sensitivity * Time.fixedDeltaTime * (Input.GetAxis("Mouse X")));

            camRotation.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime;
            camRotation.x = Mathf.Clamp(camRotation.x, minAngle, maxAngle);
        }
        else
            camRotation.x = 80f;
    }

}
