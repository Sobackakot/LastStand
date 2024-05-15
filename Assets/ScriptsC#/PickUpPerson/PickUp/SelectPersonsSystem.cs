
using System.Collections.Generic;
using UnityEngine; 

public class SelectPersonsSystem : MonoBehaviour
{ 
    private CharacterSwitchingSystem characterSystem;

    public GUISkin GUISkin; 
    private Rect rectTransform;
    private bool drawFrame;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private int sortingLayer = 99; 
   
    private void Start()
    {
        characterSystem = CharacterSwitchingSystem.Instance; 
    }

    private void OnGUI()
    {  
        GUI.skin = GUISkin;
        GUI.depth = sortingLayer;
        StartSelect();
        StaySelect();
        EndSelect();
    }
    private Vector2 CheckPersonsFromScreen(PickUpPerson person)
    {
        float pointX = Camera.main.WorldToScreenPoint(person.transform.position).x;
        float pointY = Camera.main.WorldToScreenPoint(person.transform.position).y;
        Vector2 screenPoint = new Vector2(pointX, Screen.height - pointY);
        return screenPoint;
    }
    private void SelectPersons(Rect rectTransform)
    {
        foreach(var pick in characterSystem.PersonsSquad)
        {
            Vector2 screenPoint = CheckPersonsFromScreen(pick);
            if (rectTransform.Contains(screenPoint))
            {
                characterSystem.EnableComponentsPerson(pick);
            }
            else characterSystem.DisableComponentsPerson(pick);
        }
    } 
    private void StartSelect() // start of character selection
    {    
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
            drawFrame = true;
        }
    } 
    private void StaySelect()// selection process while pressing the button
    {  
        if(Input.GetMouseButton(0)) 
        {
            if (drawFrame)
            {
                endPoint = Input.mousePosition;
                if (startPoint == endPoint) return;
                rectTransform = GetInvertRectByScreenPoint(startPoint, endPoint);
                GUI.Box(rectTransform, "");
                SelectPersons(rectTransform);
            }
        } 
    }
    private void EndSelect() //finishing the selection with a frame of characters
    {
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = Input.mousePosition;
            drawFrame = false; 
        }
    }
    private Rect GetInvertRectByScreenPoint(Vector2 startPoint, Vector2 endPoint) //invert frame for negative values
    {   

        float minPointX = Mathf.Min(endPoint.x, startPoint.x);
        float maxPointX = Mathf.Max(endPoint.x, startPoint.x);

        float minPointY = Mathf.Min(endPoint.y, startPoint.y);
        float maxPointY = Mathf.Max(endPoint.y, startPoint.y);

        float pointsX = minPointX;
        float pointsY = Screen.height - maxPointY;
        float widthX = maxPointX - minPointX;
        float heightY = maxPointY - minPointY;

        return rectTransform = new Rect(pointsX, pointsY, widthX, heightY);
    } 
}
