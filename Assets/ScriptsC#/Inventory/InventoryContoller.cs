
using System;
using System.Collections.Generic;
using UnityEngine; 

public class InventoryContoller : MonoBehaviour
{    
    public static InventoryContoller Instance;

    [HideInInspector] public DragAndDropItem currentItem;
    private Transform inventoryTransform;

    public readonly List<ItemScrObj> itemsList = new List<ItemScrObj>();

    public event Action onUpdateInventorySlots;

    private int space = 48;

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
    private void Start()
    {
        inventoryTransform = GetComponent<Transform>();
        currentItem = inventoryTransform.GetChild(2).GetComponent<DragAndDropItem>();
    }
    public bool AddItemToInventoty(ItemScrObj newItem) //call from  PickUpItems 
    {
        if (itemsList.Count >= space) return false;
        itemsList.Add(newItem);
        onUpdateInventorySlots?.Invoke();
        return true;
    }
    public void RemoveItemFromInventoty(ItemScrObj newItem)
    { 
        itemsList.Remove(newItem);
        onUpdateInventorySlots?.Invoke();
    }
}
