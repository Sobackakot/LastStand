using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPerson : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform lookPoint;

    [SerializeField] private float sensitivity = 0.5f;
    [SerializeField] private float minAngle = -45f;
    [SerializeField] private float maxAngle = 65f;

    [SerializeField] private float zoomSpeed = 6f;
    [SerializeField] private float minZoom = 2f;
    [SerializeField] private float maxZoom = 100f;
    
    private float scrollDelta = 3f;  
    private float deltaX = 0f;
    private float deltaY = 0f;

    private void Start()
    {
        offset = transform.position - lookPoint.position;
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        transform.position = transform.localRotation * offset + lookPoint.position;
        transform.position = lookPoint.position - transform.forward * scrollDelta;
    }
    public void RotateCamera(Vector2 deltaMouse)
    {
        deltaX += deltaMouse.x * sensitivity;
        deltaY -= deltaMouse.y * sensitivity;
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(deltaY, deltaX, 0); 
    }
    public void ZoomCamera(Vector2 scrollMouse)
    {   
        scrollDelta-= scrollMouse.y * zoomSpeed * Time.deltaTime;
        scrollDelta = Mathf.Clamp(scrollDelta, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); 
    }
}
