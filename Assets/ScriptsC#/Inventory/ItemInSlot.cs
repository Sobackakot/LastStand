 
public class ItemInSlot 
{
    public ItemScrObj itemScrObj { get; private set; }
    public int itemAmount { get; private set; } 
    public string itemName { get; private set; }   
    public ItemInSlot(ItemScrObj item, int itemAmount)
    {
        this.itemScrObj = item;
        this.itemAmount = itemAmount;
    }
}
