 
using System.Collections.Generic;

public class InventoryPerson  
{

    public List<ItemScrObj> itemsInvetory;

    public InventoryPerson()
    {
        itemsInvetory = new List<ItemScrObj>();
    }

    public void AddItem(ItemScrObj itemScrObj)
    {
        itemsInvetory.Add(itemScrObj);
    }
    public void RemoveItem(ItemScrObj itemScrObj)
    {
        itemsInvetory.Remove(itemScrObj);
    }
    public ItemScrObj FindItemById(string id)
    {
        return itemsInvetory.Find(item => item.Id == id);
    }
}
