
using System;
using UnityEngine; 

public class PickUpItems : Interactable
{   
    [SerializeField] private ItemScrObj item; 
     
     
    private InventoryContoller inventoty;
    private void Start()
    {
        inventoty  = InventoryContoller.Instance;
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
            bool isPickUp = inventoty.AddItem(item);
            if (isPickUp)
            {
                Debug.Log("PickUpItem");
                Destroy(gameObject);
            }
        } 
    }
}
      
