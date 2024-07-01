using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private InputContorlCamera inputControlCamera;
    public override void InstallBindings()
    {
        Container.Bind<InputContorlCamera>().FromInstance(inputControlCamera).AsSingle();
        Container.Bind<CameraLookTarget>().AsSingle();
    }
}
