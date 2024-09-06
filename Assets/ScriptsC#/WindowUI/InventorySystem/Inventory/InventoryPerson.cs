 
using System.Collections.Generic; 

public class InventoryPerson  
{
    public readonly List<ItemScrObj> itemsInventory;
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
                return true; 
            }
        } 
        indexSlot = -1;
        return false; // InventoryPerson is full
    }

    public void RemoveItemFromInventory(out int slotIndex, ItemScrObj newItem) // coll from class InventoryController
    {
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == newItem)
            {
                itemsInventory[i] = null;
                slotIndex = i;
                return;
            }
        }
        slotIndex = -1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    } 

    public void SwapItemInSlot(int slotIndex, ItemScrObj newItem) // coll from class InventorySlot
    { 
        if (slotIndex >= 0 && slotIndex < space) 
        {
            UpdateInventoryPerson(newItem);
            itemsInventory[slotIndex] = newItem; //update item indexes when changing inventory slots
        }
    }
    private void UpdateInventoryPerson(ItemScrObj newItem)
    {
        for (int i = 0; i < itemsInventory.Count; i++)
        {
            if (itemsInventory[i] == newItem)
            {
                itemsInventory[i] = null; //clearing the original slot when moving an item to another slot
                return;
            }
        } 
    } 
}
