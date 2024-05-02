
using System;
using UnityEngine;

public class CameraRayPointMove : MonoBehaviour
{   
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform lookPoint; // таргет за кем слудует камера
    [SerializeField] private LayerMask terraLayerMask; // слой Маска поверхности 
    [SerializeField] private float verticalRayDistanc = 2000f; // длина луча
    [SerializeField] private float speedMoveRay = 15f;
    public event Func<Vector2> onInputGetAxis;

    private Vector3 directionX; // текущее направление камеры  
    private Vector3 directionZ; // текущее направление камеры  
    private Vector3 newDirectionMove;// новое направление передвижения луча в зависимости от направления камеры
     

    private float inputAxisX = 0f;
    private float inputAxisZ = 0f;
    
    private void Update()
    {
        GetDirectionCamera();
        SetRaycastPoint();
        MoveRay();
        SetInputAxisMove(onInputGetAxis.Invoke());
    }
    private void SetInputAxisMove(Vector2 inputAxis) 
    {   
        inputAxisX = inputAxis.x;
        inputAxisZ = inputAxis.y; 
    }
    private void GetDirectionCamera()
    {
        directionX = mainCamera.right; // получаем направление камеры
        directionZ = mainCamera.forward;// получаем направление камеры
        directionX.y = 0; // обнуляем вертикальную ось 
        directionZ.y = 0; // обнуляем вертикальную ось  
        newDirectionMove = (directionX * inputAxisX) + (directionZ * inputAxisZ).normalized; // получаем нвое напрвления движения
    }
    private void SetRaycastPoint()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);// создаем луч в направлении сверху в низ
        if (Physics.Raycast(ray, out RaycastHit hit, verticalRayDistanc, terraLayerMask))// проверем столкновение луча с поверхностью
        {
            lookPoint.position = hit.point;// перемещяем объект Target LookPoint камеры в позицию пересечения луча с поверхностью
        } 
    }
    private void MoveRay()
    { 
        if (newDirectionMove.sqrMagnitude > 0) 
            transform.Translate(newDirectionMove * speedMoveRay * Time.deltaTime); // передвигаем луч по напрвлению камеры 
    }
}
     

