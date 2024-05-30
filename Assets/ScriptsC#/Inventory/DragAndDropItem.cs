
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler,IPointerDownHandler,IPointerUpHandler
{ 
    private RectTransform pickItemTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private ItemScrObj dataItem;
    private Image iconItem;
    private TextMeshProUGUI nameItem;
    private TextMeshProUGUI amountItem;
    private bool isDragging = false;

    private void Awake()
    {
        pickItemTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = pickItemTransform.GetComponentInParent<Canvas>();
        iconItem = GetComponent<Image>();
        nameItem = pickItemTransform.GetChild(0).GetComponent<TextMeshProUGUI>();
        amountItem = pickItemTransform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.9f;
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
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Debug.Log("EndDrugg");
    }

    public void UpdatePointEnter(RectTransform enterPoint)
    {
        gameObject.SetActive(true);
        canvasGroup.alpha = 0.2f;
        pickItemTransform.position = enterPoint.position;
    }
    public void PickUpItemInSlot(ItemScrObj newData)
    { 
        dataItem = newData;
        iconItem.sprite = dataItem.IconItem;
        nameItem.text = dataItem.NameItem;
        amountItem.text = dataItem.item.itemAmount.ToString();
    }
    public bool IsDragging()
    {
        return isDragging;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }
}
