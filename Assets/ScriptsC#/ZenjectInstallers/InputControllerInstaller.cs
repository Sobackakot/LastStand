using UnityEngine;
using Zenject;

public class InputControllerInstaller : MonoInstaller
{ 
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<InputControllerCamera>().AsSingle().NonLazy(); 
        Container.Bind<CameraLookTarget>().FromComponentInHierarchy().AsSingle();
        Container.Bind<RaycastPointFollow>().AsSingle();
    }
}
