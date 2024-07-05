 
using UnityEngine;

public class PersonSpawnPoint : MonoBehaviour
{
    public Transform transformPoint {  get; private set; }  
    private void Awake()
    {
        transformPoint = GetComponent<Transform>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
