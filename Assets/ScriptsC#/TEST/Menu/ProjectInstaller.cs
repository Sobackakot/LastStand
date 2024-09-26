
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "Installer(Project)", menuName = "Installer/ProjectInstaller")]
public class ProjectInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameObject character;
    public override void InstallBindings()
    {
        Container.Bind<ButtonsListener>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<MoveblePerson>().AsCached();
        Container.BindInterfacesAndSelfTo<InputMove>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<Character>().FromComponentInNewPrefab(character).AsSingle();
    }
}
