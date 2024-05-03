 
using UnityEngine; 

public class CameraPerson : MonoBehaviour  
{
    [Header("Current Camera position")]
    [SerializeField] private Vector3 offset;

    [Header("Target Look Person point")]
    [SerializeField] private Transform lookPoint;

    [Header("Mouse Rotate Camera")]
    [SerializeField, Range(0.3f,3)] private float sensitivity = 0.5f;
    [SerializeField, Range(-65, 0)] private float minAngle = -45f;
    [SerializeField, Range(0, 65)] private float maxAngle = 65f;

    [Header("Mouse Zoom Camera")]
    [SerializeField, Range(1,30)] private float currentScrollPoint = 6f;
    [SerializeField, Range(1, 10)] private float zoomSpeed = 6f;
    [SerializeField, Range(1, 6)] private float minZoom = 2f;
    [SerializeField, Range(25, 500)] private float maxZoom = 100f;
    
      
    private float deltaX;
    private float deltaY; 

    private void Start()
    {
        offset = transform.position - lookPoint.position; // получаем стартовую позицию камеры от таргета
        //Cursor.lockState = CursorLockMode.Locked;
    }
    public void LateUpdate()
    {
        PositionUpdate();
    }
    public virtual void PositionUpdate()
    {
        transform.position = transform.localRotation * offset + lookPoint.position; //обновление позии камеры при вращении
        transform.position = lookPoint.position - transform.forward * currentScrollPoint; //обновление позиции камеры при зууме
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
