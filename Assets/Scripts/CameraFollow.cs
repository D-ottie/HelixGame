using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public float smoothSpeed = 0.04f;

    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 newPosition = target.position + offset;  to make motion smoother we use the code below
        Vector3 newPosition = Vector3.Lerp(transform.position , target.position + offset , smoothSpeed);
        transform.position = newPosition;
    }
}
