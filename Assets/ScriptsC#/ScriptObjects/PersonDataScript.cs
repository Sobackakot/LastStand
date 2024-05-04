using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{
    public string Name;
    public string Id;
    public Sprite sprite;
}
