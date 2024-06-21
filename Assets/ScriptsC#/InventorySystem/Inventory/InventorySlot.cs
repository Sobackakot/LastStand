 
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler   
{ 
    private RectTransform transformSlot;
    
    private void Awake()
    {   
        transformSlot = GetComponent<RectTransform>();   
    }   

    public virtual void AddItemInSlot(ItemInSlot item, ItemScrObj data)
    {
        item.SetItem(data);
    }
    public virtual void RemoveItemInSlot(ItemInSlot item)
    {
        item.CleareItem();
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        ItemInSlot dropedItem = eventData.pointerDrag.GetComponent<ItemInSlot>();  
        ItemScrObj originItemData = dropedItem.GetItemData();
        if (transformSlot.childCount > 0 && originItemData!=null)
            DropItemInSlot(originItemData, dropedItem);
    }
    private void DropItemInSlot(ItemScrObj originItemData, ItemInSlot dropedItemInSlot)
    {    
        ItemInSlot pickItemInSlot = transformSlot.GetChild(0).GetComponent<ItemInSlot>();
        ItemScrObj currentItemData = pickItemInSlot.GetItemData();
        pickItemInSlot.SetItem(originItemData);
        if (currentItemData != null)
            dropedItemInSlot.SetItem(currentItemData);
        else dropedItemInSlot.CleareItem();
    }

}
