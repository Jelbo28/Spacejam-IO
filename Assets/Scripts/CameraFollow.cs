using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{ 
    public Transform target;
    public float smoothing = 5f;
    private bool trackTarget  = false;
    Vector3 offset;

    void Start()
    {
        offset = transform.position;
    }

    void FixedUpdate()
    {
        if (trackTarget == true)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }

    public void SetTarget(Transform player)
    {
        target = player;
        transform.position = target.GetChild(0).transform.position;
        transform.rotation = target.GetChild(0).transform.rotation;
        offset = transform.position - target.position;
        trackTarget = true;
    }
}
