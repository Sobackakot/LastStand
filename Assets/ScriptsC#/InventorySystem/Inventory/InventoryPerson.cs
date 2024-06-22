 
using System.Collections.Generic; 
using UnityEngine;

public class InventoryPerson  
{
    public List<ItemScrObj> itemsInventory;
    private int space = 48;
    public InventoryPerson()
    {
        itemsInventory = new List<ItemScrObj>(space);
        for (int i = 0; i < space; i++)
        {
            itemsInventory.Add(null); // Initialize the list with null values 
        } 
    }

    public bool AddItemToInventory(out int indexSlot, ItemScrObj newItem) //coll from InventoryController
    { 
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == null)
            {
                itemsInventory[i] = newItem;
                indexSlot = i;
                Debug.Log("InventoryPerson Add " + newItem.NameItem + "  " + i);
                return true; 
            }
        } 
        indexSlot = -1;
        return false; // InventoryPerson is full
    }

    public void RemoveItemFromInventory(out int slotIndex, ItemScrObj newItem) // coll from InventoryController
    {
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == newItem)
            {
                itemsInventory[i] = null;
                slotIndex = i;
                Debug.Log("InventoryPerson Remove " + newItem.NameItem + "  " + i);
                return;
            }
        }
        slotIndex = -1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    } 

    public void SwapItemInSlot(int slotIndex, ItemScrObj newItem)
    { 
        if (slotIndex >= 0 && slotIndex < space)
        {
            UpdateInventoryPerson(newItem);
            itemsInventory[slotIndex] = newItem;
            Debug.Log("InventoryPerson  ToSet " + newItem.NameItem + "  " + slotIndex);
        }
    }
    private void UpdateInventoryPerson(ItemScrObj newItem)
    {
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == newItem)
            {
                itemsInventory[i] = null; 
                Debug.Log("InventoryPerson FromSet " + newItem.NameItem + "  " + i);
                return;
            }
        } 
    } 
}
