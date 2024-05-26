
using System.Collections.Generic;
using UnityEngine; 

public class Inventory : MonoBehaviour
{   
    public static Inventory Instance;
    [SerializeField] private List<ItemScrObj> itemsList = new List<ItemScrObj>(); 
    private int space = 3;
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }
    public bool AddItem(ItemScrObj item)
    {
        if (itemsList.Count >= space) return false;
        itemsList.Add(item);
        return true;
    }
    public void RemoveItem(ItemScrObj item)
    {
        itemsList.Remove(item);
    }
}
