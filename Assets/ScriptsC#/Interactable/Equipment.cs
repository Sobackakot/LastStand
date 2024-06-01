
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryContoller/Equip Item")]
public class Equipment : ItemScrObj
{
    public float Armor;
    public float Damage;
    public EquipItem IndexOfSlot;
    public override void Use()
    {
        base.Use();
    }
}
public enum EquipItem
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
