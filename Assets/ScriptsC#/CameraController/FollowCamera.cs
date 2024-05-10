using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{ 
    [SerializeField] private Transform raycastPosition;
    [SerializeField] private Transform currentTarget;

    private float maxRadius = 50f;
    private float smoothSpeed = 1f;
    private Vector3 direction;
    private void OnDisable()
    {
        CharacterSwitchingSystem.Instance.onSetNewTargetFolowCamera -= SetTargetPlayer;
    }
    private void Start()
    {
        CharacterSwitchingSystem.Instance.onSetNewTargetFolowCamera += SetTargetPlayer;
    }
    private async void LateUpdate()
    {
        RadiusCameraClamp();
        await Task.Delay(200);
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
