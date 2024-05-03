 
using UnityEngine; 

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonScriptObject : ScriptableObject
{
    public string Name = "";
    public int Id = 0;
    public Sprite image; 
} 
