
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryController/Equip Item")]
public class Equipment : ItemScrObj
{
    public float Armor;
    public float Damage;
    public EquipItem IndexOfSlot; //slots for equipping items
    public override void UseItem() 
    {
        base.UseItem();//coll from class ItemInSlot
        EquipmentController.Instance.EquipItem(this);
        RemoveItemFromInventorySlot();
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
    Weapon_2 
}
