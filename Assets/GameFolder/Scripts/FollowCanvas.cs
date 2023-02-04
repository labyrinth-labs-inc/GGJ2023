using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCanvas : MonoBehaviour
{
    public Transform headset;
    public float distanceLimit = 1f;
    public float smoothSpeed = 0.125f;
    public Vector3 offset = new Vector3(0,0,2);

    void Awake()
    {
        transform.position = headset.TransformPoint(offset);
        transform.LookAt(headset);
        
    }

    void FixedUpdate()
    {
        float distance  = Vector3.Distance(transform.position, headset.TransformPoint(0,0,offset.z));
        // if(distance < 1) return;
        Vector3 desiredPos = headset.TransformPoint(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(headset);
    }
}
