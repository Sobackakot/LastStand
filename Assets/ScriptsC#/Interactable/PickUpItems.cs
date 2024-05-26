
using System;
using UnityEngine; 

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item;
    private Inventory inventory;
    private void Start()
    {
        inventory = Inventory.Instance;
    }
    public override void Interaction()
    {
        base.Interaction();
        PickUpItem();
    }
    private void PickUpItem()
    {   
        if(item.isDefaultItem)
        {
            bool isPickUp = inventory.AddItem(item);
            if (isPickUp)
            {
                Debug.Log("PickUpItem");
                Destroy(gameObject);
            }
        } 
    }
}
      
