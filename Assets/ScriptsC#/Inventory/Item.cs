

using UnityEngine; 

public class Item  
{
    public string id;
    public int Amount;
    public string name;
    public Sprite spriteItem;
    public Item(string _id, int amount, Sprite _spriteItem)
    {
        id = _id;
        Amount = amount;
        spriteItem = _spriteItem;   
    }
}
