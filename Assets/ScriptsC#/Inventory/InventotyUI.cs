
 
using UnityEngine;

public class InventotyUI : MonoBehaviour
{ 
    private Transform trnasformInventoty;
    private InventorySlot[] slots;
    private void Awake()
    {    
        trnasformInventoty = GetComponent<Transform>();
        slots = trnasformInventoty.GetComponentsInChildren<InventorySlot>();
    }
    private void Start()
    {
        InventoryContoller.Instance.onUpdateInventorySlots += UpdateInventorySlots;
    }
    private void OnDisable()
    {
        InventoryContoller.Instance.onUpdateInventorySlots -= UpdateInventorySlots;
    }
    private void UpdateInventorySlots()
    {
        foreach(InventorySlot slot in slots)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (i < InventoryContoller.Instance.itemsList.Count)
                {
                    slots[i].AddItemToSlot(InventoryContoller.Instance.itemsList[i]);
                }
                else
                {
                    slots[i].CleareSlot();
                }
            }
        }
    }
}
