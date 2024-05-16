
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    
    [Header("RaycastPointFollow - Script")]
    [SerializeField] private Transform raycastPosition;
    [Header("Follow new Person point")]
    [SerializeField] private Transform currentTarget;

    private float maxRadius = 50f;
    private float smoothSpeed = 1f;
    private Vector3 direction;
    private void OnDisable()
    {
        CharacterSwitchSystem.Instance.onSetNewTargetFolowCamera -= SetTargetPlayer;
    }
    private void Start()
    {
        CharacterSwitchSystem.Instance.onSetNewTargetFolowCamera += SetTargetPlayer;
    }
    private void LateUpdate()
    {
        RadiusCameraClamp(); 
    }
    public void SetTargetPlayer(Transform newTarget)
    {
        currentTarget = newTarget;
    }
    private void RadiusCameraClamp()
    { 
        direction = transform.position - currentTarget.position;
        if (direction.sqrMagnitude > maxRadius * maxRadius)
        {
            direction.Normalize();
            direction = Vector3.ClampMagnitude(direction, maxRadius);
            Vector3 currentOffsetY = new Vector3(currentTarget.position.x + direction.x, raycastPosition.position.y, currentTarget.position.z + direction.z);
            raycastPosition.position = Vector3.Lerp(raycastPosition.position, currentOffsetY, Time.deltaTime * smoothSpeed);
        }
    }
}
