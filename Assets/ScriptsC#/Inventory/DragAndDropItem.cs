
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{    

    private ItemScrObj itemScrObj;
     
    private RectTransform pickItemTrnasform;
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Image currentIconItem;
    private TextMeshProUGUI currentAmountItem;
    private TextMeshProUGUI currentNameItem; 

    private void Awake()    
    {    
        pickItemTrnasform = GetComponent<RectTransform>();
        canvas = pickItemTrnasform.GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        currentIconItem = GetComponent<Image>();
        currentNameItem = pickItemTrnasform.GetChild(0).GetComponent<TextMeshProUGUI>();
        currentAmountItem = pickItemTrnasform.GetChild(1).GetComponent<TextMeshProUGUI>(); 
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        pickItemTrnasform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void PickUpItem(ItemScrObj itemInSlot, RectTransform rectTrnasform)
    {
        gameObject.SetActive(true);
        pickItemTrnasform.position = rectTrnasform.position;
        itemScrObj = itemInSlot;
        currentIconItem.sprite = itemScrObj.IconItem;
        currentAmountItem.text = itemScrObj.item.itemAmount.ToString();
        currentNameItem.text = itemScrObj.NameItem;  
    }
    public void DropPickItem(out ItemScrObj newItemScrObj)
    {
        newItemScrObj = itemScrObj;
        currentIconItem.sprite = null;
        currentAmountItem.text = " ";
        currentNameItem.text = " ";
    }
}
