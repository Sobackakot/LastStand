
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Entity", menuName = "Entity/Person")]
public class PersonDataScript : ScriptableObject
{   
    public string Name = "No name";
    private string Id = "No id - 0";
    public Sprite sprite = null;
    [SerializeField, Range(0, 100)]
    public float currentHP = 100f;
    public bool isInstalled = false;
    public string GetCurrenPersonId()
    {
        if(!isInstalled)
        {
            Id = Guid.NewGuid().ToString();
            isInstalled =true;
        }
        return Id;
    }

    public IEnumerator LoadSpriteAsync(string assetPath)
    {
        ResourceRequest request = Resources.LoadAsync<Sprite>(assetPath);
        yield return request;
        sprite = request.asset as Sprite;
    }
    public UnityEvent valueChanged;

#if UNITY_EDITOR
    private void OnValidate()
    {
        // Этот метод вызывается в редакторе Unity при каждом изменении значения. 
        // Вызов UnityEvent при изменении значений. 
        if(UnityEditor.EditorApplication.isPlaying)
        {
            valueChanged.Invoke(); // Запускаем UnityEvent
        }
    }
#endif
}
