

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
    private void Start()
    {
        for(int i  =0; i < ItemsInSlot.Count; i++)
        {
            ItemsInSlot[i].slotIndex = i;
        }
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
            if(ItemsInSlot[i].dataItem != null)
            {
                Slots[i].RemoveItemInSlot(ItemsInSlot[i]);
            }
            if (i < items.Count && items[i]!=null)
            {
                Slots[i].AddItemInSlot(ItemsInSlot[i], items[i]);
            }
        }
    }
    public void SwapItemsInSlot(ItemInSlot fromItem, ItemInSlot toItem)
    {
        int fromIndex = fromItem.slotIndex;
        int toIndex = toItem.slotIndex;
        inventory.SetItemInSlot(fromIndex, toItem.dataItem);
        inventory.SetItemInSlot(toIndex, fromItem.dataItem); 
    }
      
}
