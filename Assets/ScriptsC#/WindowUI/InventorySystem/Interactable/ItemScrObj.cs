
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

    public float Armor;
    public float Damage;
    public EquipItem IndexOfSlot; //slots for equipping items
    
    public void SetIdFromNewItem()
    {
        if (isInstaled)
        {
            Id = Guid.NewGuid().ToString();
            isInstaled = true;
        }
    } 
}
public enum EquipItem : byte
{    
    Helmet,
    T_shirt,
    Vest,
    Gloves,
    Trousers,
    Shoes,
    Backpack,
    Belt,
    Shield,
    Weapon_1,
    Weapon_2,
    None
}
