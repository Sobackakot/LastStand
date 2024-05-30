
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour
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

    public void OnBeginDragItem()
    {
        canvasGroup.alpha = 0.6f; 
        Debug.Log("BeginDrugg");
    }
    public void OnDragItem()
    {
        if (!isDragging) return; 
        pickItemTransform.position = Input.mousePosition;
        Debug.Log("Drugg");
    }
    public void OnEndDragItem()
    {
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
    public void DropItemInSlot(out ItemScrObj currentData)
    {
        currentData = dataItem; 
        dataItem = null;
        iconItem.sprite = null;
        nameItem.text = " ";
        amountItem.text = " ";
        gameObject.SetActive(false);
    }
    public bool IsDragging()
    {
        Debug.Log("isDrugging = " + isDragging);
        return isDragging; 
    }

    public void OnPointerDownItem()
    {
        isDragging = true;
    }

    public void OnPointerUpItem()
    {
        isDragging = false;
    }
}
