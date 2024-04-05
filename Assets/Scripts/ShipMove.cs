using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShipMove : MonoBehaviour
{ 
    [SerializeField] Camera cam;

    Vector3 mousePosition, newRotation, newPosition;
    public bool canChangePos, move;
    public float speed;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        canChangePos = true;
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float singleStep = speed * Time.deltaTime;

        Vector3 camPos = new Vector3(newPosition.x, newPosition.y, -10);
        Vector3 direction = transform.position - mousePosition;

        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, singleStep * 2f);

        if (Input.GetMouseButtonDown(0) && canChangePos)
        {
            newPosition = mousePosition;
            move = true;
            canChangePos = false;
        }

        if (move)
        {
            transform.position = Vector2.Lerp(transform.position, newPosition, singleStep);
            cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, singleStep / 4f);

            if (Vector2.Distance(transform.position, newPosition) < 0.5f)
            {
                move = false;
                canChangePos = true;
            }
        }
    }
}
