using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public float frequency;
    public float magnitude;
    float phase;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        phase += Time.deltaTime;
        Vector3 pos = startPosition;
        float x = magnitude * Mathf.Sin(phase * frequency);
        pos.x = x;
        transform.position = pos;
    }
}
