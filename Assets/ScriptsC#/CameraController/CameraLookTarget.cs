
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

    [Header("Mouse Rotate Camera")]
    [SerializeField, Range(0.3f,3)] private float sensitivity = 0.5f;
    [SerializeField, Range(-75, 0)] private float minAngle = -45f;
    [SerializeField, Range(0, 75)] private float maxAngle = 75f;

    [Header("Mouse Zoom Camera")]
    [SerializeField, Range(1,30)] private float currentScrollPoint = 6f;
    [SerializeField, Range(1, 10)] private float zoomSpeed = 6f;
    [SerializeField, Range(1, 6)] private float minZoom = 2f;
    [SerializeField, Range(25, 500)] private float maxZoom = 100f;

   

    private Transform currentLookPoint; // тукущая точка следования камеры 

    private float deltaX;
    private float deltaY;

    private void OnEnable()
    {
        inputContorlCamera.onRotateMouse += RotateCamera;
        inputContorlCamera.onScrollMouse += ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint += ResetLookPoint;
    }
    private void OnDisable()
    {
        inputContorlCamera.onRotateMouse -= RotateCamera;
        inputContorlCamera.onScrollMouse -= ZoomCamera;
        raycastPointFollow.onResetTargetLookPoint -= ResetLookPoint;
    }
    private void Start()
    { 
        currentLookPoint = lookFreePoint;
        offset = transform.position - currentLookPoint.position; // получаем стартовую позицию камеры от таргета 
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        PositionUpdate();
    } 
    public void ResetLookPoint(bool isFreeCamera, PickUpPerson person = null) //call from SystemPersonData
    { 
        // либо камера следует за выбранным из списка персонажем или свободно следует за точкой
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
        transform.position = transform.localRotation * offset + currentLookPoint.position; //обновление позии камеры при вращении
        transform.position = currentLookPoint.position - transform.forward * currentScrollPoint; //обновление позиции камеры при зууме
    }
    public virtual void RotateCamera(Vector2 deltaMouse)
    {
        deltaX += deltaMouse.x * sensitivity; // получаем дельту вращения по X
        deltaY -= deltaMouse.y * sensitivity; // получаем дельту вращения по Y
        deltaY = Mathf.Clamp(deltaY, minAngle, maxAngle); // ограничение вращения по Y
        transform.localEulerAngles = new Vector3(deltaY, deltaX, 0); // инициализация вращения камеры толко с зажатой кнопкой
    }
    public virtual void ZoomCamera(Vector2 scrollMouse)
    {   
        currentScrollPoint-= scrollMouse.y * zoomSpeed * Time.deltaTime; // получаем значения Zoom камеры вперед/назад
        currentScrollPoint = Mathf.Clamp(currentScrollPoint, Mathf.Abs(minZoom), Mathf.Abs(maxZoom)); // ограничения Zoom 
    } 
}
