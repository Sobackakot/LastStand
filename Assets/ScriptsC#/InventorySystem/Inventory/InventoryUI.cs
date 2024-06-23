

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
        inventory.onSetNewItemByInventoryCell += SetNewItemByInventoryCell;
        inventory.onResetItemByInventoryCell += ResetItemByInventoryCell;
        inventory.onUpdateInventoryPerson += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        inventory.onSetNewItemByInventoryCell -= SetNewItemByInventoryCell;
        inventory.onResetItemByInventoryCell -= ResetItemByInventoryCell;
        inventory.onUpdateInventoryPerson -= UpdateInventorySlots;
    }
    private void SetNewItemByInventoryCell(int slotIndex) //coll from InventoryController
    { 
        List<ItemScrObj> items = inventory.GetCurrentInventory();
        if (slotIndex < items.Count && items[slotIndex] != null) //updates the inventory user interface, those slots that have been changed
        {
            Slots[slotIndex].AddItemInSlot(ItemsInSlot[slotIndex], items[slotIndex]);
        }
    }
    private void ResetItemByInventoryCell(int slotIndex) //coll from InventoryController
    {
        List<ItemScrObj> items = inventory.GetCurrentInventory();
        if (slotIndex < items.Count) //updates the inventory user interface, those slots that have been changed
        {
            Slots[slotIndex].RemoveItemInSlot(ItemsInSlot[slotIndex]);
        }
    }
    private void UpdateInventorySlots() //coll from InventoryController
    { 
        List<ItemScrObj> items = inventory.GetCurrentInventory();
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
