
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

public class GameSceneInstaller : MonoInstaller, IInitializable
{
    [SerializeField] private AssetReferenceGameObject otherPersonsReference;

    [SerializeField] private RaycastPointFollow raycastPointFollow;
    [SerializeField] private CameraLookTarget cameraLookTarget;
    [SerializeField] private FollowCamera freePoint;

    [SerializeField] private Transform myPersonStartPoint;
    [SerializeField] private GameObject myPersonPrefab;
     
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

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameSceneInstaller>().FromInstance(this).AsSingle();
        Container.Bind<IPersonFactory>().To<PersonFactory>().AsSingle();
        Container.Bind<AssetReferenceGameObject>().WithId(OtherPersons_ID).FromInstance(otherPersonsReference);

        BindTransformCameraSystem();
        BindInputCamera();
        BindCharacterSwitch();
        BindPrefabMyPerson();
    }
    public async void Initialize()
    {
        var personFactory = Container.Resolve<IPersonFactory>();
        await personFactory.LoadPersonsAsync();
        foreach (var point in points)
        {
            personFactory.SetPointsSpawn(point.transformPoint.position);
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

    private void BindPrefabMyPerson()
    {
        PickUpPerson myPerson = Container
            .InstantiatePrefabForComponent<PickUpPerson>(myPersonPrefab, myPersonStartPoint.position, Quaternion.identity, null);
        Container.Bind<PickUpPerson>().FromInstance(myPerson).AsSingle();
        Container.Bind<Transform>().FromInstance(myPerson.transform).AsSingle(); 
    }
     
}
