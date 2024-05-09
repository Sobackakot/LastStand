 
using UnityEngine; 

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{   
    public string Name = "No name"; 
    public Sprite sprite = null; 

    public PersonData data; 
}
