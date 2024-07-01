using UnityEngine;
using Zenject;

public class CameraSystemInstaller : MonoInstaller
{ 
    public override void InstallBindings()
    {
        InputControllerCamera();
    }
    private void InputControllerCamera()
    {
        Container.BindInterfacesAndSelfTo<InputControllerCamera>().AsSingle().NonLazy();
        Container.Bind<CameraLookTarget>().AsSingle();
        Container.Bind<RaycastPointFollow>().AsSingle();
    }
}
