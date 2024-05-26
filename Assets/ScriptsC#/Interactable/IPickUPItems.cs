
using System;

public interface IPickUPItems  
{
    public event Func<ItemScrObj, bool> OnItemAddList;
}
