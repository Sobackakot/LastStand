
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Transform transformSlot;
    private Image itemIcon;
    private TextMeshProUGUI itemName;
    private TextMeshProUGUI itemAmount;
    private ItemScrObj itemScrObj;

    private void Awake()
    {
        transformSlot = GetComponent<Transform>(); 
        itemIcon = transformSlot.GetChild(0).GetComponent<Image>();
        itemName = transformSlot.GetChild(1).GetComponent<TextMeshProUGUI>();
        itemAmount = transformSlot.GetChild(2).GetComponent<TextMeshProUGUI>(); 
    }
    public void AddItemToSlot(ItemScrObj newItem)
    {   
        itemScrObj = newItem; 
        itemName.text = itemScrObj.NameItem;
        itemAmount.text = itemScrObj.ItemAmount.ToString(); 
        itemIcon.sprite = itemScrObj.IconItem;
        itemIcon.enabled = true;
    }
    public void CleareSlot()
    {
        itemScrObj = null; 
        itemIcon.sprite = null;
        itemIcon.enabled = false;
        itemName.text = " ";
        itemAmount.text = " ";
    }
}
