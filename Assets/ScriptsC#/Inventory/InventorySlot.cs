
using TMPro; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class InventorySlot : MonoBehaviour, IDropHandler
{ 
    private ItemScrObj dataItem;
     
    private RectTransform transformSlot;

    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    
    private void Awake()
    {   
        transformSlot = GetComponent<RectTransform>();  
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = itemIcon.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        itemAmount = itemIcon.transform.GetChild(1).GetComponent<TextMeshProUGUI>(); 
    } 
    public void AddItemToSlot(ItemScrObj newItem) // coll from InventotyUI
    {   
        if(newItem == null) return;
        dataItem = newItem; 
        itemName.text = dataItem.NameItem;
        itemAmount.text = dataItem.item.itemAmount.ToString();
        itemIcon.sprite = dataItem.IconItem;
        itemIcon.enabled = true; 
    }
    public void CleareSlot() // coll from InventotyUI
    {
        dataItem = null; 
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " ";
    }

    public void CheckCurrentItemInSlot()
    {
        if (dataItem != null && dataItem.item.itemAmount < 1)
        {
            CleareSlot(); 
        } 
    } 

    public void OnDrop(PointerEventData eventData)
    { 
        DragAndDropItem dropedItem = eventData.pointerDrag.GetComponent<DragAndDropItem>();   
        if(dropedItem == null) return;
        Transform originalPoint = dropedItem.currentTransform;
        // Swap items between the current slot and the dropped item's slot
        if (originalPoint != transformSlot)
        {
            // Move the current item (if any) to the dropped item's original slot
            if (transformSlot.childCount > 0)
            {
                Transform currentPoint = transformSlot.GetChild(0);
                currentPoint.SetParent(originalPoint);
            }
            // Move the dropped item to the current slot
            dropedItem.currentTransform = transformSlot;
        } 
    }

}
