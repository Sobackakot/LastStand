
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameSceneInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private AssetReferenceGameObject otherPersonsReference;
    [SerializeField] private AssetReferenceGameObject firsPersonsReference;

    [SerializeField] private RaycastPointFollow raycastPointFollow;
    [SerializeField] private CameraLookTarget cameraLookTarget;
    [SerializeField] private FollowCamera freePoint;

    [SerializeField] private Transform myPersonStartPoint; 
     
    [SerializeField] private PersonMoveControl personMoveControl;

    [SerializeField] private CharacterSwitchSystem characrterSwitch;

    [SerializeField] private PickUpPerson pickUpPerson;
    [SerializeField] private PickUpPersonUI pickUpPersonUI;
    [SerializeField] private SelectPersonsSystem selectPersonsSystem;
    [SerializeField] private GridLayoutGroupPerson gridLayoutGroupPerson;

    [SerializeField] private List<PersonSpawnPoint> points;

    private const string Raycast_ID = "raycastPoint";
    private const string LookPoint_ID = "lookFreePoint";
    private const string OtherPersons_ID = "otherPersons";
    private const string FirstPersons_ID = "firstPerson";

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameSceneInstaller>().FromInstance(this).AsSingle();
        
        BindTransformCameraSystem();
        BindInputCamera();
        BindCharacterSwitch();
        BindPrefabFirstPerson();
        BindPrefabOtherPersons();
    }
     
    public async void Initialize()
    {
        var personFactory  = Container.Resolve<SpawnFirstPerson>();
        personFactory.SetPointSpawn(myPersonStartPoint.position);
        personFactory.LoadPerson();

        var personsFactory = Container.Resolve<IPersonFactory>(); 
        await personsFactory.LoadPersonsAsync();
        foreach (var point in points)
        {
            personsFactory.SetPointsSpawn(point.transformPoint.position);
        }
    }
    

    private void BindTransformCameraSystem()
    {
        Container.Bind<RaycastPointFollow>().FromInstance(raycastPointFollow).AsSingle();
        Container.Bind<CameraLookTarget>().FromInstance(cameraLookTarget).AsSingle();
        Container.Bind<FollowCamera>().FromInstance(freePoint).AsSingle();

        Container.Bind<Transform>().WithId(Raycast_ID).FromInstance(raycastPointFollow.transform); 
        Container.Bind<Transform>().WithId(LookPoint_ID).FromInstance(freePoint.transform);
    }

    private void BindCharacterSwitch()
    { 
        Container.Bind<PersonDataManager>().FromNew().AsSingle().NonLazy();
        Container.Bind<PickUpPersonUI>().FromInstance(pickUpPersonUI).AsSingle();
        Container.Bind<SelectPersonsSystem>().FromInstance(selectPersonsSystem).AsSingle();
        Container.Bind<GridLayoutGroupPerson>().FromInstance(gridLayoutGroupPerson).AsSingle();
        Container.Bind<CharacterSwitchSystem>().FromInstance(characrterSwitch).AsSingle();
    }

    private void BindInputCamera()
    {
        Container.BindInterfacesAndSelfTo<InputControllerCamera>().AsSingle().NonLazy(); 
        Container.Bind<Camera>().FromInstance(cameraLookTarget.gameObject.GetComponent<Camera>()).AsSingle();
        Container.Bind<PersonMoveControl>().FromInstance(personMoveControl).AsSingle();
    }
    private void BindPrefabOtherPersons()
    {
        Container.Bind<IPersonFactory>().To<PersonFactory>().AsSingle();
        Container.Bind<AssetReferenceGameObject>().WithId(OtherPersons_ID).FromInstance(otherPersonsReference);
    }

    private void BindPrefabFirstPerson()
    {
        Container.Bind<AssetReferenceGameObject>().WithId(FirstPersons_ID).FromInstance(firsPersonsReference);
        Container.BindInterfacesAndSelfTo<SpawnFirstPerson>().AsSingle().NonLazy();
      
        Container.Bind<PickUpPerson>().FromInstance(pickUpPerson).AsSingle();
        Container.Bind<Transform>().FromInstance(pickUpPerson.transform).AsSingle(); 
    }
     
}
