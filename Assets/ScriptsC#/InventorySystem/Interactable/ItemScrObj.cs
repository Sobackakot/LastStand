
using System;
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

    private bool isInstaled;
    public virtual void UseItem() //coll from class ItemInSlot 
    {

    }
    public void RemoveItemFromInventorySlot() //coll from class Equipment
    {
        InventoryController.Instance.RemoveItemFromInventory(this);
    }
    public void SetIdFromNewItem()
    {
        if (isInstaled)
        {
            Id = Guid.NewGuid().ToString();
            isInstaled = true;
        }
    } 
}
