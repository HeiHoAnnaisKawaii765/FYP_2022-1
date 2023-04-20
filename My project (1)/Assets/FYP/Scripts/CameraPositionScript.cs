using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionScript : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    public float smoothSpeed = 0.12f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        //transform.LookAt(target.position);
        transform.position = Vector3.Lerp(transform.position , target.position + offset, Time.deltaTime * smoothSpeed);
    }
}
