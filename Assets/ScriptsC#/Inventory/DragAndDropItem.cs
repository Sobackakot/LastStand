
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{     
    private ItemScrObj itemScrObj;

    private Transform currentItem;
    private Image currentIconItem;
    private TextMeshProUGUI currentAmountItem;
    private TextMeshProUGUI currentNameItem;
    private int AmountItem;
    private void Awake()
    {
        currentItem = GetComponent<Transform>();
        currentIconItem = currentItem.GetChild(0).GetComponent<Image>();
        currentAmountItem = currentItem.GetChild(1).GetComponent<TextMeshProUGUI>();
        currentNameItem = currentItem.GetChild(2).GetComponent<TextMeshProUGUI>();  
    }
    public void OnBeginDrag(PointerEventData eventData)
    { 
    }

    public void OnDrag(PointerEventData eventData)
    { 
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
    }

    public void OnPointerDown(PointerEventData eventData)
    { 
    }
    public void PickUpItem(ItemInSlot itemInSlot)
    {   
        itemScrObj = itemInSlot.itemScrObj;
        currentIconItem.sprite = itemScrObj.IconItem;
        currentAmountItem.text = itemScrObj.item.itemAmount.ToString();
        currentNameItem.text = itemScrObj.NameItem;
    }
    public void DropPickItem(ItemScrObj newItemScrObj)
    {
        newItemScrObj = itemScrObj;
        newItemScrObj.IconItem = currentIconItem.sprite;
        currentNameItem.text = newItemScrObj.NameItem;
    }
}
