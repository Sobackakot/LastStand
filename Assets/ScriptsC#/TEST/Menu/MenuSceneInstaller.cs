
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuSceneInstaller : MonoInstaller
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;
    public override void InstallBindings()
    {
         Container.BindInterfacesAndSelfTo<ButtonsEvent>().AsCached().WithArguments(this.startButton, this.exitButton).NonLazy();
    }
}
