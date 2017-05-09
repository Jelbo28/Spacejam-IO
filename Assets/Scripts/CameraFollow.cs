using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public float panSpeed = 5;
    public float panRange = 250;
    private Vector3 movement;
    private int theScreenWidth;
    private int theScreenHeight;

    public Transform target;
    public float smoothing = 5f;
    public bool trackTarget = false;
    Vector3 offset;
    private Vector3 targetCamPos;

    void Start()
    {
        offset = transform.position;
        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;
    }

    void FixedUpdate()
    {
        if (trackTarget)
        {
            targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
        if (Input.GetMouseButton(1))
        {
            if (Input.mousePosition.x >= theScreenWidth && movement.x < panRange)
            {
                movement.x += panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.x <= 0 && movement.x > -panRange)
            {
                movement.x -= panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.y >= theScreenHeight && movement.z < panRange)
            {
                movement.z += panSpeed * Time.deltaTime;
            }

            if (Input.mousePosition.y <= 0 && movement.z > -panRange)
            {
                movement.z -= panSpeed * Time.deltaTime;
            }
            transform.position = new Vector3(movement.x + transform.position.x, transform.position.y, movement.z + transform.position.z);
        }
        else
        {
            movement = Vector3.zero;
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
