using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    private bool isFocus = false;
    private Transform player;
    private Transform interact;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    private void Awake()
    {
        interact = GetComponent<Transform>();    
    }
    private void LateUpdate()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, interact.position);
            if (distance < radius)
            {
                Interaction();
            }
        }
    }
    public virtual void Interaction()
    {
       //Interactable 
    }
    public void OnFocused(Transform _player)
    {
        player = _player;
        isFocus = true;
    }
    public void OnDefocus()
    {   
        player = null;
        isFocus = false;
    }
}
