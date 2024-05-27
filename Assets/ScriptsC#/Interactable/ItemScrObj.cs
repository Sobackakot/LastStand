 
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "InventoryContoller/Item")]
public class ItemScrObj :ScriptableObject
{
    public Item item;
    public string Id { get; private set; }
    public string NameItem;
    public Sprite IconItem;
    public float WEIGHT;
    public bool isDefaultItem;
    public bool isStackable;
}
