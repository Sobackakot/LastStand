 
using Zenject;

public class InstallerSystem : MonoInstaller
{
    public override void InstallBindings()
    {
         Container.BindInterfacesAndSelfTo<MoveblePerson>().FromNew().AsCached().NonLazy(); 
         Container.BindInterfacesAndSelfTo<InputMove>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Character>().FromComponentInHierarchy().AsSingle(); 
    }
}
