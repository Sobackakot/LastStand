
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems; 

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Transform trnasformItem;
    private RectTransform pickItemTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
     
    private void Awake()    
    {
        trnasformItem = GetComponent<Transform>();
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>(); 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        trnasformItem = transform.parent;
        pickItemTransform.SetParent(transform.root);
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
        pickItemTransform.SetParent(trnasformItem);
    }  
}
