using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;

[RequireComponent(typeof(NetworkObject))]
public class PlayerLook : MonoBehaviour
{
    [SerializeField] int minAngle, maxAngle, sensitivity;
    private Vector3 camRotation;
    NetworkObject networkObject;

    public bool rotate = true;
    public Camera cam;

    private void Start()
    {
        networkObject = GetComponent<NetworkObject>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if(networkObject.IsOwner)
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
