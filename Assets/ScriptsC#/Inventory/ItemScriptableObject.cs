

using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class ItemScriptableObject : ScriptableObject
{
    public string Id { get; private set; }
    public string Name { get; private set; } 
    public int Count { get; private set; }
    public Sprite sprite {  get; private set; }
}
