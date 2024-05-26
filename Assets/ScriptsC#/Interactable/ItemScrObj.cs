 
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryContoller/Item")]
public class ItemScrObj :ScriptableObject
{
     public string Id { get; private set; }
    public string NameItem;
    public Sprite IconItem;
    public int ItemAmount;
    public bool isDefaultItem;
}
