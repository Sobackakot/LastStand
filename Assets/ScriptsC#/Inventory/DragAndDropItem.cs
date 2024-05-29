
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [HideInInspector] public Transform originalParent;
    private RectTransform pickItemTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

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
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        pickItemTransform.SetParent(originalParent); 
        // If the item was not dropped on a valid slot, return it to its original position
        if(transform.parent == canvas.transform)
        {
            pickItemTransform.SetParent(originalParent);
            pickItemTransform.anchoredPosition = Vector2.zero;
        }
    }
}
