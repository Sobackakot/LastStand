
using System;
using UnityEngine;

public class CameraRayPointMove : MonoBehaviour
{   
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform lookPoint; // ������ �� ��� ������� ������
    [SerializeField] private LayerMask terraLayerMask; // ���� ����� ����������� 
    [SerializeField] private float verticalRayDistanc = 2000f; // ����� ����
    [SerializeField] private float speedMoveRay = 15f;
    public event Func<Vector2> onInputGetAxis;

    private Vector3 directionX; // ������� ����������� ������  
    private Vector3 directionZ; // ������� ����������� ������  
    private Vector3 newDirectionMove;// ����� ����������� ������������ ���� � ����������� �� ����������� ������
     

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
        directionX = mainCamera.right; // �������� ����������� ������
        directionZ = mainCamera.forward;// �������� ����������� ������
        directionX.y = 0; // �������� ������������ ��� 
        directionZ.y = 0; // �������� ������������ ���  
        newDirectionMove = (directionX * inputAxisX) + (directionZ * inputAxisZ).normalized; // �������� ���� ���������� ��������
    }
    private void SetRaycastPoint()
    {
        Ray ray = new Ray(transform.position, -Vector3.up);// ������� ��� � ����������� ������ � ���
        if (Physics.Raycast(ray, out RaycastHit hit, verticalRayDistanc, terraLayerMask))// �������� ������������ ���� � ������������
        {
            lookPoint.position = hit.point;// ���������� ������ Target LookPoint ������ � ������� ����������� ���� � ������������
        } 
    }
    private void MoveRay()
    { 
        if (newDirectionMove.sqrMagnitude > 0) 
            transform.Translate(newDirectionMove * speedMoveRay * Time.deltaTime); // ����������� ��� �� ���������� ������ 
    }
}
     

