 
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{
    public string Name = "No name";
    public string Id = "No id - 0";
    public Sprite sprite = null;
    public bool isHasPick = false;
}