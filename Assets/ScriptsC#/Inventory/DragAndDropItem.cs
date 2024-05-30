
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Transform originalParent;
    private RectTransform pickItemTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private bool isDragging = false;

    private void Awake()
    {
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        Debug.Log("BeginDrugg");
    }
    public void OnDrag(PointerEventData eventData)
    {
        pickItemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log("Drugg");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Debug.Log("EndDrugg");
    }

    public void UpdatePointEnter(RectTransform enterPoint)
    {
        if (isDragging) return;
        gameObject.SetActive(true);
        canvasGroup.alpha = 0.2f;
        pickItemTransform.position = enterPoint.position;
        Debug.Log("EnterPoint");
    }
    public bool IsDragging()
    {
        return isDragging;
    }
    public void OnPointerDown(PointerEventData eventData)
    { 
        isDragging = true;
        Debug.Log("downItem");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
