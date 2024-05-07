 

public class InitializedIComponent 
{       
    ICharacterComponent characterComponent; 
    public InitializedIComponent(ICharacterComponent newComponent) 
    {
        characterComponent = newComponent;
    }
    public void EnableComponent()
    {
        characterComponent.OnEnableComponent();
    }
    public void DisableComponent()
    {
        characterComponent.OnDisableComponent();
    }
}
