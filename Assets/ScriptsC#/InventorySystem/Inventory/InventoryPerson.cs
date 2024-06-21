 
using System.Collections.Generic; 

public class InventoryPerson  
{
    private Dictionary<int, ItemScrObj> itemsInSlotInventoryPerson;
    public List<ItemScrObj> itemsInventory;
    private int space = 48;
    public InventoryPerson()
    {
        itemsInSlotInventoryPerson = new Dictionary<int, ItemScrObj>();
        itemsInventory = new List<ItemScrObj>(space);
        for (int i = 0; i < space; i++)
        {
            itemsInventory.Add(null); // Initialize the list with null values
            itemsInSlotInventoryPerson.Add(i, null);
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
    public ItemScrObj GetItemInSlot(int slotIndex)
    {
        if (itemsInSlotInventoryPerson.TryGetValue(slotIndex, out ItemScrObj item))
        {
            return item;
        }
        return null;
    }

    public void SetItemInSlot(int slotIndex, ItemScrObj newItem)
    {
        if (itemsInSlotInventoryPerson.ContainsKey(slotIndex))
        {
            itemsInSlotInventoryPerson[slotIndex] = newItem;
        }
    }
}
