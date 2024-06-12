 
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryController/Item")]
public class ItemScrObj : ScriptableObject
{
    public Item item;
    public string Id { get; private set; }
    public string NameItem;
    public Sprite IconItem;
    public float Weight;
    public bool isDefaultItem;
    public bool isStackable;
    
    public virtual void UseItem()
    {

    }
    public void RemoveItemFromInventorySlot()
    {
        InventoryController.Instance.RemoveItemFromInventory(this);
    }
}
