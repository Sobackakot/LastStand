 
using System.Collections.Generic; 

public interface ICharacterComponent  
{   
    ICharacterComponent GetComponent();
    void OnEnableComponent();
    void OnDisableComponent();
}
