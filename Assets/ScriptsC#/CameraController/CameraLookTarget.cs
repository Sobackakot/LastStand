
using UnityEngine; 

public class CameraLookTarget : MonoBehaviour  
{
    [Header("EventSystem Camera Input Contoller")]
    [SerializeField] private InputContorlCamera inputContorlCamera;
    [Header("EventSystem RaycastPointFollow")]
    [SerializeField] private RaycastPointFollow raycastPointFollow;

    [Header("Transform: Target Look Point")]
    [SerializeField] private Transform lookFreePoint; 
    [Header("Current Camera position")]
    [SerializeField] private Vector3 offset; 
     
    [Range(0.3f,3)] private float sensitivity = 0.5f;
    [Range(-75, 0)] private float minAngle = -45f;
    [Range(0, 75)] private float maxAngle = 75f;

    [Range(1,30)] private float currentScrollPoint = 6f;
    [Range(1, 10)] private float zoomSpeed = 2f;
    [Range(1, 6)] private float minZoom = 2f;
    [Range(25, 500)] private float maxZoom = 100f;

    private Transform cameraPoint;// ��������� ������� ������
    private Transform currentLookPoint; // ������� ����� ���������� ������ 

    private float deltaX;
    private float deltaY;

    private void OnEnable()
    {
        inputContorlCamera.onRotateMouse += RotateCamera;
        inputContorlCamera.onScrollMouse += ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint += ResetLookPoint;
        CharacterSwitchingSystem.Instance.onResetFocusCamera += ResetLookPoint;
    }
    private void OnDisable()
    {
        inputContorlCamera.onRotateMouse -= RotateCamera;
        inputContorlCamera.onScrollMouse -= ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint -= ResetLookPoint;
        CharacterSwitchingSystem.Instance.onResetFocusCamera -= ResetLookPoint;
    }
    private void Start()
    {
        cameraPoint = GetComponent<Transform>();
        currentLookPoint = lookFreePoint;
        offset = cameraPoint.position - currentLookPoint.position; // �������� ��������� ������� ������ �� ������� 
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        PositionUpdate();
    } 
    public void ResetLookPoint(bool isFreeCamera, PickUpPerson person = null) //call from CharacterSwitchingSystem
    { 
        // ���� ������ ������� �� ��������� �� ������ ���������� ��� �������� ������� �� ������
        if (isFreeCamera)
        {
            currentLookPoint = lookFreePoint;
        } 
        else
        { 
            currentLookPoint = person.transform;
        }
    }
    public virtual void PositionUpdate()
    {
        cameraPoint.position = cameraPoint.localRotation * offset + currentLookPoint.position; //���������� ����� ������ ��� ��������
        cameraPoint.position = currentLookPoint.position - cameraPoint.forward * currentScrollPoint; //���������� ������� ������ ��� �����
    }
    public virtual void RotateCamera(Vector2 deltaMouse)
    {
        deltaX += deltaMouse.x * sensitivity; // �������� ������ �������� �� X
        deltaY -= deltaMouse.y * sensitivity; // �������� ������ �������� �� Y
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle); // ����������� �������� �� Y
        cameraPoint.localEulerAngles = new Vector3(deltaY, deltaX, 0); // ������������� �������� ������ ����� � ������� �������
    }
    public virtual void ZoomCamera(Vector2 scrollMouse)
    {   
        currentScrollPoint-= scrollMouse.y * zoomSpeed * Time.deltaTime; // �������� �������� Zoom ������ ������/�����
        currentScrollPoint = Mathf.Clamp(currentScrollPoint, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); // ����������� Zoom 
    } 
}
