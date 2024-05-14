 
using UnityEngine; 

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{
    public string namePerson; 

    public Sprite spritePerson; 

    public PersonData data; 
}
