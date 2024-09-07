
using UnityEngine;
using Zenject;

public class GlobalInstaller :MonoInstaller
{
    [SerializeField] private GameObject characterSwitchPrefab;
    public override void InstallBindings()
    {
        BindSaveSystem();
    }
    private void BindSaveSystem()
    {
        Container.BindInterfacesAndSelfTo<PersonDataManager>().AsSingle().NonLazy();
        Container.Bind<CharacterSwitchSystem>().FromComponentInNewPrefab(characterSwitchPrefab).AsSingle().NonLazy();
    }
}
