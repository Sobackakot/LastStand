
using UnityEngine; 

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{
    public string namePerson;
    public Vector3 position;

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
        position = data.LoadPositionPerson();
    }
    private void OnDisable()
    {
        data.SavePositionPerson(position);
    }
}
