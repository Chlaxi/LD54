using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera cam;
    [SerializeField]
    private Vector3 cameraOffset;
    private Vector3 cameraStartOffset;
    private float baseSize;
    private bool _isMoving = false;

    public Transform target;
    [SerializeField]
    private float targetDistForFollow = 1f;
    [SerializeField, Range(0f, 1f)]
    private float smoothSpeed = 0.125f;

    private void Awake()
    {
        cam = Camera.main;
        cameraStartOffset = cameraOffset;
        baseSize = Camera.main.orthographicSize;
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        Vector3 desiredPosition = target.position + cameraOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
