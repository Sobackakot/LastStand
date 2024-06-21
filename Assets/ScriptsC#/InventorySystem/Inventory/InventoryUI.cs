

using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryController inventory; 
    private List<ItemInSlot> ItemsInSlot = new List<ItemInSlot>();
    private List<InventorySlot> Slots = new List<InventorySlot>();


    private void Awake()
    {
        ItemsInSlot.AddRange(GetComponentsInChildren<ItemInSlot>(false));
        Slots.AddRange(GetComponentsInChildren<InventorySlot>(false)); 
    }
    private void OnEnable()
    {
        inventory = InventoryController.Instance;
        inventory.onUpdateInventorySlots += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        inventory.onUpdateInventorySlots -= UpdateInventorySlots; 
    }
    private void UpdateInventorySlots() //coll from InventoryController
    { 
        List<ItemScrObj> items = inventory.GetCurrentInventory();
        for (int i = 0; i < Slots.Count; i++)
        {
            if (i < items.Count)
            {
                Slots[i].AddItemInSlot(ItemsInSlot[i],items[i]); 
            }
            if(items[i] == null)
            {
                Slots[i].RemoveItemInSlot(ItemsInSlot[i]);
            }
        }
    }
    private void SwapItemsInSlot(ItemInSlot fromItem, ItemInSlot toItem)
    {
        int fromIndex = fromItem.slotIndex;
        int toIndex = toItem.slotIndex;
        inventory.SetItemInSlot(fromIndex,toItem.dataItem);
    }
      
}
