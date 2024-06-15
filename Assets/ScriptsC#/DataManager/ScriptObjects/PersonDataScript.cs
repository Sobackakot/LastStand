 
using UnityEngine; 

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{
    public string namePerson; 

    public Sprite spritePerson; 

    public PersonData data;

    public InventoryPerson inventoryPerson;
    public EquipmentPerson equipmentPerson;

    private void OnEnable()
    {
        if (inventoryPerson == null)
            inventoryPerson = new InventoryPerson();
        if (equipmentPerson == null)
            equipmentPerson = new EquipmentPerson();
    }
}
