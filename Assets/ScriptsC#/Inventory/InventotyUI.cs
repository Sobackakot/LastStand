
 
using UnityEngine;

public class InventotyUI : MonoBehaviour
{
    private InventoryContoller inventory;
    private Transform trnasformInventoty;
    private InventorySlot[] slots;
    private void Awake()
    { 
        trnasformInventoty = GetComponent<Transform>();
        slots = trnasformInventoty.GetComponentsInChildren<InventorySlot>(); 
    }
    private void Start()
    {
        inventory = InventoryContoller.Instance;
        inventory.onUpdateInventorySlots += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        inventory.onUpdateInventorySlots -= UpdateInventorySlots;
    }
    private void UpdateInventorySlots() //coll from InventoryContoller
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.itemsList.Count)
            {
                slots[i].AddItemToSlot(inventory.itemsList[i]);
            }
            else
            {
                slots[i].CleareSlot();
            }
        }
    }
}
