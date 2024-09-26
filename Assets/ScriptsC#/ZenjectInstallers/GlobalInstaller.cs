
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Installer(Project)", menuName = "Installer/Global")]
public class GlobalInstaller : ScriptableObjectInstaller
{ 
    public override void InstallBindings()
    {
        BindSaveSystem();
    }
    private void BindSaveSystem()
    {
        Container.Bind<SaveDataSystem>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PersonsDataList>().FromNew().AsSingle().NonLazy();

    }
}
