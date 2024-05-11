
using System; 
using UnityEngine;  
public class RaycastPointFollow : MonoBehaviour
{
    [Header("EventSystem Input Controller Camera")]
    [SerializeField] private InputContorlCamera inputControlCamera;

    [Header("Camera Person")]
    [SerializeField] private Transform mainCamera;

    [Header("Target Look Point")]
    [SerializeField] private Transform lookFreePoint; // target who the camera is following

    [Header("Terrane Layer Mask")]
    [SerializeField] private LayerMask terraLayerMask; // layer Surface mask

    [Range(510,2000)] readonly float verticalRayDistance = 510f; // beam length
    [Range(10, 500)] readonly float offsetY = 500f; 

    [Range(1,50)] private float speedMoveRay = 15f; // beam movement speed

    private Transform rayPoint;
     

    public event Action<bool, PickUpPerson> onResetTargetLookPoint;//this Event for class CameraLookTarget

    private Vector3 directionX;// current camera direction
    private Vector3 directionZ; // current camera direction
    private Vector3 newDirectionMove;// new direction of beam movement depending on the camera direction

    private float inputAxisX;
    private float inputAxisZ;
    private void Start()
    {
        rayPoint = GetComponent<Transform>();
    }
    private void OnEnable()
    { 
        inputControlCamera.onInputGetAxis += SetInputAxisMove; 
    }
    private void OnDisable()
    {
        inputControlCamera.onInputGetAxis -= SetInputAxisMove; 
    } 
    private void LateUpdate()
    {
        GetDirectionCamera();
        MoveRay();
        SetRaycastPoint();  
    }
    public void EnableMoveRay()
    {
        enabled = true;
    }
    public void DisableMoveRay()
    {
        enabled = false;
    }
    private void SetInputAxisMove(Vector2 inputAxis)  
    {   
        inputAxisX = inputAxis.x;
        inputAxisZ = inputAxis.y;
        onResetTargetLookPoint?.Invoke(true, null); 
    }
    private void GetDirectionCamera()
    {
        // Normalize the camera's right and forward vectors to ignore vertical movement
        Vector3 directionX = Vector3.ProjectOnPlane(mainCamera.right, Vector3.up);
        Vector3 directionZ = Vector3.ProjectOnPlane(mainCamera.forward, Vector3.up);

        newDirectionMove = ((directionX * inputAxisX) + (directionZ * inputAxisZ)).normalized;// get a new direction of movement
    }
    private void SetRaycastPoint()
    {
        Ray ray = new Ray(rayPoint.position, -Vector3.up);// create a ray in the direction from top to bottom
        if (Physics.Raycast(ray, out RaycastHit hit, verticalRayDistance, terraLayerMask))// check the collision of the ray with the surface
        {
            lookFreePoint.position = hit.point;// moved object Target Look Point of the camera
                                               // to the position of intersection of the ray with the surface 
            //Logic to adjust Y coordinate based on terrain height using raycasting.
            transform.position = new Vector3(transform.position.x, hit.point.y + offsetY, transform.position.z);
        }
    }
    private void MoveRay()
    {
        rayPoint.position += newDirectionMove * speedMoveRay * Time.deltaTime;
        // move the beam in the direction of the camera
    } 
} 

