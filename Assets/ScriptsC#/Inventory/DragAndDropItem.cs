
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{     
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
        pickItemTransform.SetParent(pickItemTransform.root);
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
        pickItemTransform.SetParent(pickItemTransform.parent);
    }  
}
