

using System;
using System.Collections.Generic;

public interface IInventoryUI<T>
{
    event Func<List<ItemScrObj>> onSetNewItem;
    void SetNewItemByInventoryCell(T value);
    void ResetItemByInventoryCell(T value);
    void UpdateInventorySlots();
}