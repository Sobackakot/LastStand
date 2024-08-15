
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Zenject;

public class OnPointerEnterUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public static event Action <bool> onPointerEnterUI; // event for class PersonMoveControl,SelectPersonsSystem   
    private InventoryController inventory;

    [Inject]
    private void Container(InventoryController inventory)
    {
        this.inventory = inventory;
    }
    private void Start()
    {
        inventory.onPointerExit += OnPointerExit;
    } 
    private void OnDisable()
    {
        inventory.onPointerExit -= OnPointerExit;
    }
    public void OnPointerEnter(PointerEventData eventData) 
    { 
        onPointerEnterUI?.Invoke(true);//checks the position of the mouse cursor on ui elements
    }

    public void OnPointerExit(PointerEventData eventData) 
    { 
        onPointerEnterUI?.Invoke(false);//checks the position of the mouse cursor on ui elements
    }
    private void OnPointerExit()
    {
        onPointerEnterUI?.Invoke(false);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
