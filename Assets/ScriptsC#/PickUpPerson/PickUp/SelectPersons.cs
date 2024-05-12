using UnityEngine;
using UnityEngine.UI;

public class SelectPersons : MonoBehaviour
{ 
    [SerializeField] private InputGameController inputGameController; 
    [SerializeField] private Image frameImage; 
     
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 minPoint;
    private Vector2 maxPoint; 
     
    private void OnEnable()
    {
        inputGameController.onLeftMouseButtonDown += StartSelect;
        inputGameController.onSelectStayMouseButton += StaySelect;
        inputGameController.onLeftMouseButtonUp += EndSelect;
    }
    private void OnDisable()
    {
        inputGameController.onLeftMouseButtonDown -= StartSelect;
        inputGameController.onSelectStayMouseButton -= StaySelect;
        inputGameController.onLeftMouseButtonUp -= EndSelect; 
    }
    private void StartSelect()
    {    
        frameImage.enabled = true;
        startPoint = Input.mousePosition;
    } 
    private void StaySelect()
    {
        endPoint = Input.mousePosition;
        SetRectScreenPoin();
    } 
    private void EndSelect()
    {
        endPoint = Input.mousePosition; 
        frameImage.enabled = false;
    }


    private void SetRectScreenPoin()
    {
        minPoint = Vector2.Min(startPoint, endPoint);
        maxPoint = Vector2.Max(startPoint, endPoint);
        frameImage.rectTransform.anchoredPosition = minPoint;
        frameImage.rectTransform.sizeDelta = maxPoint - minPoint;
    } 
}
