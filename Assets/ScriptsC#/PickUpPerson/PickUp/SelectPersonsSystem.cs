
using System.Collections.Generic;
using UnityEngine; 

public class SelectPersonsSystem : MonoBehaviour
{ 
    private List<PickUpPerson> personsSquad = new List<PickUpPerson>();
    public GUISkin GUISkin; 
    private Rect rectTransform;
    private bool drawFrame;

    private Vector2 startPoint;
    private Vector2 endPoint;
    private int sortingLayer = 99;
     
    private void OnGUI()
    {  
        GUI.skin = GUISkin;
        GUI.depth = sortingLayer;
        StartSelect();
        StaySelect();
        EndSelect();
    }

    private void UpdateListPersonsBySelect(PickUpPerson person)
    {   
        if(!personsSquad.Contains(person))
                personsSquad.Add(person);
        else personsSquad.Remove(person);
    }
    private void SelectPersons()
    {
    }
    private void DeselectPersons()
    {

    }
    private void StartSelect() // start of character selection
    {    
        if(Input.GetMouseButtonDown(0))
        {
            DeselectPersons();
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
            }
        } 
    }
    private void EndSelect() //finishing the selection with a frame of characters
    {
        if (Input.GetMouseButtonUp(0))
        {
            SelectPersons();
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
