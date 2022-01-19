using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraManager : MonoBehaviour
{
    [Range(0f, 20f)] public float xRotateSensitivity = 5f;
    [Range(0f, 20f)] public float yRotateSensitivity = 5f;
    [Range(0f, 1f)] public float moveSpeed = 0.5f;

    public void Start()
    {
        // centerPos = new Vector3(10, 2, 10);
        // transform.position = centerPos + Vector3.back * 2 + Vector3.up * 2;
        // transform.LookAt(centerPos);
    }

    public void Update()
    {
        var mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(transform.position, Vector3.up, mouse.x * xRotateSensitivity);
            var orig = transform.rotation;
            transform.RotateAround(transform.position, Vector3.Cross(Vector3.up, transform.forward),
                -mouse.y * yRotateSensitivity);
            if (transform.rotation.eulerAngles.z > 45)
            {
                transform.rotation = orig;
                Debug.Log(transform.rotation.eulerAngles);
            }
        }

        var movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
        
        transform.position +=
            (transform.right * movement.x + transform.up * movement.y + transform.forward * movement.z)
            * moveSpeed;
    }
}