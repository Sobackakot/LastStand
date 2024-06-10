
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryController/Equip Item")]
public class Equipment : ItemScrObj
{
    public float Armor;
    public float Damage;
    public EquipItem IndexOfSlot;
    public override void Use()
    {
        base.Use();
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
