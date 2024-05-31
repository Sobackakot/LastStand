
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{ 
    private RectTransform pickItemTransform;
    [HideInInspector] public Transform currentTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
     

    private void Awake()
    {   
        currentTransform = GetComponent<Transform>();
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        currentTransform = transform.parent;
        pickItemTransform.SetParent(canvas.transform);
        pickItemTransform.SetAsLastSibling();
        Debug.Log("BeginDrugg");
    }
    public void OnDrag(PointerEventData eventData)
    {
        pickItemTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log("Drugg");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f; 
        pickItemTransform.SetParent(currentTransform);
        Debug.Log("EndDrugg");
    }
}
