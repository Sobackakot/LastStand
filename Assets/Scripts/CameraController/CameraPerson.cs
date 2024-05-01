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
        offset = transform.position - lookPoint.position; // получаем стартовую позицию камеры от таргета
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        transform.position = transform.localRotation * offset + lookPoint.position; //обновление позии камеры при вращении
        transform.position = lookPoint.position - transform.forward * scrollDelta; //обновление позиции камеры при зууме
    }
    public void RotateCamera(Vector2 deltaMouse)
    {
        deltaX += deltaMouse.x * sensitivity; // получаем дельту вращения по X
        deltaY -= deltaMouse.y * sensitivity; // получаем дельту вращения по Y
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle); // ограничение вращения по Y
        transform.localEulerAngles = new Vector3(deltaY, deltaX, 0); // инициализация вращения камеры толко с зажатой кнопкой
    }
    public void ZoomCamera(Vector2 scrollMouse)
    {   
        scrollDelta-= scrollMouse.y * zoomSpeed * Time.deltaTime; // получаем значения Zoom камеры вперед/назад
        scrollDelta = Mathf.Clamp(scrollDelta, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); // ограничения Zoom 
    } 
}
