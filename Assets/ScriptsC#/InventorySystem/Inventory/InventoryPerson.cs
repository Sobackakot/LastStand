 
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

    public bool AddItemToInventory(ItemScrObj newItem) //coll from InventoryController
    { 
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == null)
            {
                itemsInventory[i] = newItem;
                return true; 
            }
        } 
        return false; // InventoryPerson is full
    }

    public void RemoveItemFromInventory(ItemScrObj newItem) // coll from InventoryController
    {
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == newItem)
            {
                itemsInventory[i] = null; 
                return;
            }
        }
    }
}
