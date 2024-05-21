
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupPerson : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup grid;

    private readonly int minSlots = 1; 
    private readonly int maxSlots = 18;
    private readonly float minCellSize = 100f;
    private readonly float maxCellSize = 170f;

    [Range(1, 18)] private int currentSlotsCount = 1; 
    [Range(100,170)] private float currentCellSize = 100;

    private void Start()
    {
        CharacterSwitchSystem.Instance.onUpdateCellSizeGrid += Instance_onUpdateCellSizeGrid;
        Instance_onUpdateCellSizeGrid();
    }
    private void OnDisable()
    {
        CharacterSwitchSystem.Instance.onUpdateCellSizeGrid -= Instance_onUpdateCellSizeGrid;
    }

    private void Instance_onUpdateCellSizeGrid() // call from CharacterSwitchSystem - ActivePersonUI
    {
        currentSlotsCount = GetCurrentActiveSlot();
        if (currentSlotsCount <6)
        {
            //if the number of cells is less than 6, then the size will be from 170 to 130
            float cellSize = Mathf.Lerp(minCellSize, maxCellSize, (maxSlots - minSlots) / (currentSlotsCount + minSlots));
            grid.cellSize = new Vector2(cellSize, cellSize);
        }
        else  
        {
            //if the number of cells is more than six, then the size will be from 130 to 100
            currentCellSize = currentSlotsCount <= 7 ? 130 : 100;
            grid.cellSize = new Vector2(currentCellSize, currentCellSize);
        }
    }
    private int GetCurrentActiveSlot() //checks all active cells in the grid for scaling
    {
        currentSlotsCount = 0;
        foreach (Transform child in grid.transform)
        {
            //counts the current number of active cells in the UI grid
            if (child.gameObject.activeSelf)
            { 
                currentSlotsCount++; 
            }
        }
        return currentSlotsCount;
    }
}
