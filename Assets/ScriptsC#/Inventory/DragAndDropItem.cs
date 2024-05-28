
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

    private void Awake()
    {
        currentItem = GetComponent<Transform>();
        currentIconItem = GetComponent<Image>();
        currentNameItem = currentItem.GetChild(0).GetComponent<TextMeshProUGUI>();
        currentAmountItem = currentItem.GetChild(1).GetComponent<TextMeshProUGUI>();
         
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
