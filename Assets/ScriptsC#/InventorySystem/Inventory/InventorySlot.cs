 
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class InventorySlot : MonoBehaviour, IDropHandler   
{   
    private InventoryController inventory;
    private RectTransform transformSlot;

    [Inject]
    private void Container(InventoryController inventory)
    {
        this.inventory = inventory; 
    }
    private void Awake()
    {   
        transformSlot = GetComponent<RectTransform>();   
    }
     
    public virtual void AddItemInSlot(ItemInSlot item, ItemScrObj data) //coll from class InventoryUI
    {
        item.SetItem(data);
    }
    public virtual void RemoveItemInSlot(ItemInSlot item)//coll from class InventoryUI
    {
        item.CleareItem();
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        ItemInSlot dropedItem = eventData.pointerDrag.GetComponent<ItemInSlot>();  
        ItemScrObj originItemData = dropedItem.dataItem; //cell with an item into which you want to drop the current item
        if (transformSlot.childCount > 0 && originItemData != null)
        { 
            DropItemInSlot(originItemData, dropedItem); 
        }
            
    }
    private void DropItemInSlot(ItemScrObj originItemData, ItemInSlot dropedItemInSlot)
    {    
        ItemInSlot pickItemInSlot = transformSlot.GetChild(0).GetComponent<ItemInSlot>();
        ItemScrObj currentItemData = pickItemInSlot.dataItem; //item that needs to be dropped from the current slot
        inventory.SwapItemInSlot(pickItemInSlot.slotIndex, originItemData);//update the item index in the character's inventory list
        pickItemInSlot.SetItem(originItemData); //set the current item's data to a new slot

        if (currentItemData != null)
        { 
            inventory.SwapItemInSlot(dropedItemInSlot.slotIndex, currentItemData);//update the item index in the character's inventory list
            dropedItemInSlot.SetItem(currentItemData);//set the current item's data to a new slot
        } 
        else dropedItemInSlot.CleareItem();//clear the slot from the data of the previous item
    }

}
