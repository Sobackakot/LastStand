 
using UnityEngine;

// Class representing an interactable object. 
public class Interactable : MonoBehaviour
{
    public float radius = 3f; // Interaction radius.
    private bool isFocus = false; // Is the object in focus.
    private bool isHasInteract = false; // Has the interaction occurred.
    private Transform player; // Reference to the player.
    private Transform interact; // Reference to the interactable object's transform.

    // Draw the interaction radius in the editor.
    private void OnDrawGizmosSelected()
    {
        if (interact == null)
            interact = transform;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
     
    private void Awake()
    {
        interact = GetComponent<Transform>();
    }
     
    private void LateUpdate()
    {
        if (isFocus && !isHasInteract)
        {
            float distance = Vector3.Distance(player.position, interact.position); // Calculate the distance to the player.
            if (distance < radius)
            {
                Interaction(); // Perform the interaction.
                isHasInteract = true;
            }
        }
    }

    // Method to perform the interaction.
    public virtual void Interaction()
    {
        Debug.Log("Interactable");
    }

    // Method to handle when the object is focused.
    public void OnFocused(Transform _player) // coll from class PersonMoveControl
    {
        player = _player;
        isFocus = true;
        isHasInteract = false;
    }

    // Method to handle when the object is defocused.
    public void OnDefocus() // coll from class PersonMoveControl
    {
        player = null;
        isFocus = false;
        isHasInteract = false;
    }
}
