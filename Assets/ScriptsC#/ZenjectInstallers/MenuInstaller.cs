
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private MenuScene menuScene;
    public override void InstallBindings()
    {
        Container.Bind<MenuScene>().FromInstance(menuScene).AsSingle();
    }
}
