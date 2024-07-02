
using UnityEngine;
using Zenject;

// Class to manage the selection of persons.
public class SelectPersonsSystem : MonoBehaviour
{
    private CharacterSwitchSystem characrterSwitch; // Reference to the character switch system.

    public GUISkin GUISkin; // GUI skin for the selection box.
    private Rect rectTransform; // Rectangle representing the selection box.
    private bool drawFrame; // Flag to indicate if the selection box should be drawn.

    private Vector2 startPoint; // Starting point of the selection box.
    private Vector2 endPoint; // Ending point of the selection box.
    private int sortingLayer = 99; // Sorting layer for the GUI.
    private float selectionThreshold = 10f; // Minimum distance to start drawing the frame.
    private bool isPointerEnterUI = false; // to check if the mouse cursor is on the UI

    [Inject]
    private void Container(CharacterSwitchSystem characrterSwitch)
    { 
        this.characrterSwitch = characrterSwitch;
    }
    
    private void OnEnable()
    {
        OnPointerEnterUI.onPointerEnterUI += IsPointerEnterUI;
        isPointerEnterUI = false; // Reset flage
    }
    private void OnDisable()
    {
        OnPointerEnterUI.onPointerEnterUI -= IsPointerEnterUI;
        isPointerEnterUI = true; // Reset flage
    }
    private void IsPointerEnterUI(bool isPointer)
    {
        isPointerEnterUI = isPointer; 
    }
    // OnGUI is called for rendering and handling GUI events.
    private void OnGUI()
    { 
        GUI.skin = GUISkin; // Set the GUI skin.
        GUI.depth = sortingLayer; // Set the sorting layer.
        StartSelect(); // Handle the start of the selection.
        StaySelect(); // Handle the ongoing selection.
        EndSelect(); // Handle the end of the selection.
    }

    // Method to get the screen position of a person.
    private Vector2 CheckPersonsFromScreen(PickUpPerson person)
    {
        // Convert the person's world position to a screen position
        float pointX = Camera.main.WorldToScreenPoint(person.transform.position).x;
        float pointY = Camera.main.WorldToScreenPoint(person.transform.position).y;
        // Convert the world position to screen position. Convert the y-coordinate to GUI space by inverting it
        Vector2 positionFromScreen = new Vector2(pointX, Screen.height - pointY); 
        return positionFromScreen;  // Return  the screen position of the person.
    }

    // Method to select persons within the selection box.
    private void SelectPersons(Rect rectTransform)
    {
        foreach (var pick in characrterSwitch.PersonsSquad)// Iterate over each person in the character system's squad.
        {
            Vector2 positionFromSceen = CheckPersonsFromScreen(pick);// Get the screen position of the person.
            if (rectTransform.Contains(positionFromSceen)) // Check if the person's screen position is within the selection box.
            {
                // Enable components for persons inside the selection box.
                characrterSwitch.EnableComponentsPerson(pick); 
            }
            else
            {
                // Disable components for persons outside the selection box.
                characrterSwitch.DisableComponentsPerson(pick); 
            }
        }
    }

    // Method to start the selection process.
    private void StartSelect()
    {
        if (isPointerEnterUI) return; //checking that the mouse cursor does not fall into ui elements
        if (Input.GetMouseButtonDown(0))
        { 
            startPoint = Input.mousePosition; // Record the starting point of the selection.
            drawFrame = true; // Enable the drawing of the selection frame.
        }
    }

    // Method to handle the selection process while the mouse button is pressed.
    private void StaySelect()
    {
        if (Input.GetMouseButton(0) && drawFrame)
        {
            endPoint = Input.mousePosition; // Update the ending point of the selection.
            if (Vector2.Distance(startPoint, endPoint) > selectionThreshold) //check minimum frame size
            {
                // Calculate the inverted rectangle for the selection box.
                rectTransform = GetInvertRectByScreenPoint(startPoint, endPoint); 
                GUI.Box(rectTransform, ""); // Draw the selection box.
                SelectPersons(rectTransform); // Select persons within the selection box. 
            }
        }
    }

    // Method to finish the selection process.
    private void EndSelect()
    {
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition; // Finalize the ending point of the selection.
            drawFrame = false; // Disable the drawing of the selection frame.  
        }
    }

    // Method to calculate the inverted rectangle for negative values.
    private Rect GetInvertRectByScreenPoint(Vector2 startPoint, Vector2 endPoint)
    {  
        float minPointX = Mathf.Min(endPoint.x, startPoint.x);// This determines the left edge of the rectangle. 
        float maxPointX = Mathf.Max(endPoint.x, startPoint.x);// This determines the right edge of the rectangle. 
        float minPointY = Mathf.Min(endPoint.y, startPoint.y);// This determines the bottom edge of the rectangle. 
        float maxPointY = Mathf.Max(endPoint.y, startPoint.y);// This determines the top edge of the rectangle.
         
        float posX = minPointX;// This is the left edge of the rectangle. 
        float posY = Screen.height - maxPointY;// subtract the top edge value from the screen height. 
        float widthX = maxPointX - minPointX; // This is the difference between the maximum and minimum x-coordinates. 
        float heightY = maxPointY - minPointY; // This is the difference between the maximum and minimum y-coordinates.

        // Create and return a new Rect with the calculated x, y, width, and height.
        return new Rect(posX, posY, widthX, heightY);
    }
}
