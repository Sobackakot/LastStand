
using System;
using System.Collections.Generic; 
using UnityEngine; 

public class EquipmentUI : MonoBehaviour, IInventoryUI<int>
{ 
    private List<EquipmentSlot> slots = new List<EquipmentSlot>();
    private List<EquipmentItemInSlot> itemsInSlots = new List<EquipmentItemInSlot>();

    public event Func<List<ItemScrObj>> onSetNewItem;
     
    private void Awake()
    {
        slots.AddRange(GetComponentsInChildren<EquipmentSlot>(false));
        itemsInSlots.AddRange(GetComponentsInChildren<EquipmentItemInSlot>(false));
    }
    private void Start()
    {
        for(int i =0; i < slots.Count; i++)
        {
            itemsInSlots[i].equipSlotIndex = i;
        }
    } 
    public void SetNewItemByInventoryCell(int slotIndex) //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        if (slotIndex < items.Count && items[slotIndex] != null) //updates the inventory user interface, those slots that have been changed
        {
            slots[slotIndex].AddItemInSlot(itemsInSlots[slotIndex], items[slotIndex]);
        }
    }
    public void ResetItemByInventoryCell(int slotIndex) //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        if (slotIndex < items.Count) //updates the inventory user interface, those slots that have been changed
        {
            slots[slotIndex].RemoveItemInSlot(itemsInSlots[slotIndex]);
        }
    }
    public void UpdateInventorySlots() //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        for (int i = 0; i < slots.Count; i++) //Updates the inventory UI completely when changing characters
        {
            if (itemsInSlots[i].dataItem != null)
            {
                slots[i].RemoveItemInSlot(itemsInSlots[i]);
            }
            if (i < items.Count && items[i] != null)
            {
                slots[i].AddItemInSlot(itemsInSlots[i], items[i]);
            }
        }
    }
}
