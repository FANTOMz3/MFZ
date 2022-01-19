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
    public Vector3 centerPos;
    [Range(0f, 20f)] public float rotateSensitivity = 5f;
    [Range(0f, 20f)] public float moveSensitivity = 0.5f;
    [Range(0f, 20f)] public float wheelSensitivity = 0.5f;
    public float distance = 8;

    public void Start()
    {
        centerPos = new Vector3(10, 2, 10);
        transform.position = centerPos + Vector3.back * 2 + Vector3.up * 2;
        transform.LookAt(centerPos);
    }

    public void Update()
    {
        var mouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        var scroll = Input.mouseScrollDelta.y;

        if (mouse.x == 0 & mouse.y == 0 & scroll == 0) return;
        if (Input.GetMouseButton(1))
        {
            var oldRotation = transform.rotation;
            var oldPosition = transform.position;
            transform.RotateAround(
                centerPos,
                Vector3.up,
                rotateSensitivity * mouse.x);

            transform.RotateAround(
                centerPos,
                Vector3.Cross(Vector3.up, centerPos - transform.position),
                -rotateSensitivity * mouse.y);

            if (5 > transform.rotation.eulerAngles.x | 88 < transform.rotation.eulerAngles.x)
            {
                transform.rotation = oldRotation;
                transform.position = oldPosition;
            }
        }

        if (Input.GetMouseButton(2))
        {
            var eulerRotation = transform.rotation.eulerAngles / 57.29577951289617f;

            var offset = new Vector3(
                -moveSensitivity * mouse.x, 0,
                -moveSensitivity * mouse.y);

            var polarOffset = new Vector2(
                offset.magnitude,
                Mathf.Atan2(offset.x, offset.z) + eulerRotation.y);

            var nOffset = Complex.FromPolarCoordinates(polarOffset.x, polarOffset.y);

            offset = new Vector3(
                ((float) nOffset.Imaginary) * (centerPos - transform.position).magnitude / 10f, 0,
                ((float) nOffset.Real) * (centerPos - transform.position).magnitude / 10f);

            centerPos += offset;
            transform.position += offset;
        }

        if (!((centerPos - transform.position).magnitude < 1 & scroll > 0) &
            !((centerPos - transform.position).magnitude > 50 & scroll < 0))
        {
            transform.position += (centerPos - transform.position).normalized * (scroll * wheelSensitivity);
        }
    }
}