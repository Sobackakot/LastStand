

using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryUI: MonoBehaviour, IInventoryUI<int>
{ 
    private List<ItemInSlot> ItemsInSlot = new List<ItemInSlot>();
    private List<InventorySlot> Slots = new List<InventorySlot>();

    public event Func<List<ItemScrObj>> onSetNewItem;
     
    private void Awake()
    {
        ItemsInSlot.AddRange(GetComponentsInChildren<ItemInSlot>(false));
        Slots.AddRange(GetComponentsInChildren<InventorySlot>(false));
        Debug.Log(" ItemsInSlot count = " + ItemsInSlot.Count + " Slots count = " + Slots.Count);
    }
    private void Start()
    {
        for(int i  =0; i < Slots.Count; i++)
        {
            ItemsInSlot[i].slotIndex = i;
        } 
        Debug.Log(" ItemsInSlot count = " + ItemsInSlot.Count + " Slots count = " + Slots.Count);
    } 
    public void SetNewItemByInventoryCell(int slotIndex) //coll from InventoryController
    { 
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        if (slotIndex < items.Count && items[slotIndex] != null) //updates the inventory user interface, those slots that have been changed
        { 
            Slots[slotIndex].AddItemInSlot(ItemsInSlot[slotIndex], items[slotIndex]);
        }
    }
    public void ResetItemByInventoryCell(int slotIndex) //coll from InventoryController
    {
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        if (slotIndex < items.Count) //updates the inventory user interface, those slots that have been changed
        {
            Slots[slotIndex].RemoveItemInSlot(ItemsInSlot[slotIndex]);
        }
    }
    public void UpdateInventorySlots() //coll from InventoryController
    { 
        List<ItemScrObj> items = onSetNewItem?.Invoke();
        for (int i = 0; i < Slots.Count; i++) //Updates the inventory UI completely when changing characters
        {
            if (ItemsInSlot[i].dataItem != null)
            {
                Slots[i].RemoveItemInSlot(ItemsInSlot[i]);
            }
            if (i < items.Count && items[i] != null)
            {
                Slots[i].AddItemInSlot(ItemsInSlot[i], items[i]);
            }
        }
    } 
}
