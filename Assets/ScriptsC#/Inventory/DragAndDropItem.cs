
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{ 
    private RectTransform pickItemTransform;
    [HideInInspector] public Transform originalParent;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
      
    private void Awake()
    {   
        originalParent = GetComponent<Transform>();
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>(); 
    }  
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        originalParent = transform.parent;
        pickItemTransform.SetParent(canvas.transform);
        pickItemTransform.SetAsLastSibling(); 
    }
    public void OnDrag(PointerEventData eventData)
    {
        pickItemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        pickItemTransform.SetParent(originalParent);
    } 
}
