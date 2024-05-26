 
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemScrObj :ScriptableObject
{
     public string Id { get; private set; }
    public string NameItem;
    public Sprite IconItem;
    public int CountItem;
    public bool isDefaultItem;
}
