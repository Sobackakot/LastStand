
using System;
using UnityEngine;
using UnityEngine.Events;

public class RaycastPointFollow : MonoBehaviour
{
    [Header("EventSystem Input Controller Camera")]
    [SerializeField] private InputContorlCamera inputControlCamera;
    [Header("Camera Person")]
    [SerializeField] private Transform mainCamera;

    [Header("Target Look Point")]
    [SerializeField] private Transform lookFreePoint; // ������ �� ��� ������� ������

    [Header("Terrane Layer Mask")]
    [SerializeField] private LayerMask terraLayerMask; // ���� ����� ����������� 

    [Header("Settings Point Ray")]
    [SerializeField,Range(500,2000)] private float verticalRayDistance = 2000f; // ����� ����
    [SerializeField, Range(1,50)] private float speedMoveRay = 15f;
     
    //This Event for class InputController
    public event Func<Vector2> onInputGetAxis; //������� ��� ��������� ����������� �������� �� ��� X.Z

    public event Action<bool, PickUpPerson> onResetTargetLookPoint;//this Event for class CameraLookTarget

    private Vector3 directionX; // ������� ����������� ������  
    private Vector3 directionZ; // ������� ����������� ������  
    private Vector3 newDirectionMove;// ����� ����������� ������������ ���� � ����������� �� ����������� ������
      
    private float inputAxisX;
    private float inputAxisZ;
    private void OnEnable()
    {
        inputControlCamera.onInputGetAxis += SetInputAxisMove;
    }
    private void OnDisable()
    {
        inputControlCamera.onInputGetAxis -= SetInputAxisMove;
    }
    private void Update()
    {
        GetDirectionCamera();
        SetRaycastPoint();
        MoveRay();
    }
    private void SetInputAxisMove(Vector2 inputAxis)  
    {   
        inputAxisX = inputAxis.x;
        inputAxisZ = inputAxis.y;
        onResetTargetLookPoint.Invoke(true, null); 
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
        if (Physics.Raycast(ray, out RaycastHit hit, verticalRayDistance, terraLayerMask))// �������� ������������ ���� � ������������
        {
            lookFreePoint.position = hit.point;// ���������� ������ Target LookPoint ������ � ������� ����������� ���� � ������������
        } 
    }
    private void MoveRay()
    { 
        if (newDirectionMove.sqrMagnitude > 0)
        { 
            transform.Translate(newDirectionMove * speedMoveRay * Time.deltaTime); // ����������� ��� �� ���������� ������ 
        }    
    } 
}
     

