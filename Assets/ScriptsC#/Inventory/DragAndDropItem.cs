
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{     
    private ItemScrObj itemScrObj;

    private RectTransform pickItemTrnasform;
    private Image currentIconItem;
    private TextMeshProUGUI currentAmountItem;
    private TextMeshProUGUI currentNameItem; 

    private void Awake()
    {
        pickItemTrnasform = GetComponent<RectTransform>();
        currentIconItem = GetComponent<Image>();
        currentNameItem = pickItemTrnasform.GetChild(0).GetComponent<TextMeshProUGUI>();
        currentAmountItem = pickItemTrnasform.GetChild(1).GetComponent<TextMeshProUGUI>();
         
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
    }

    public void OnDrag(PointerEventData eventData)
    {
        pickItemTrnasform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
    }
    public void PickUpItem(ItemScrObj itemInSlot)
    {   
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
