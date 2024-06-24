 

public interface IInventoryUI <T>
{
    void SetNewItemByInventoryCell(T value);
    void ResetItemByInventoryCell(T value);
    void UpdateInventorySlots();
}