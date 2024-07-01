using UnityEngine;
using Zenject;

public class CameraSystemInstaller : MonoInstaller
{
    [SerializeField] private RaycastPointFollow raycastPointFollow;
    [SerializeField] private CameraLookTarget cameraLookTarget;
    public override void InstallBindings()
    {
        InputControllerCamera();
    }
    private void InputControllerCamera()
    {
        Container.BindInterfacesAndSelfTo<InputControllerCamera>().AsSingle().NonLazy(); 
        Container.Bind<RaycastPointFollow>().FromInstance(raycastPointFollow).AsSingle();
        Container.Bind<CameraLookTarget>().FromInstance(cameraLookTarget).AsSingle();
    }
}
