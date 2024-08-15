
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
    [SerializeField] private SelectPersonsSystem selectPersonsSystem;
    [SerializeField] private GridLayoutGroupPerson gridLayoutGroupPerson;

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private EquipmentUI equipmentUI;  
     

    [SerializeField] private List<PersonSpawnPoint> points;
    [SerializeField] private List<PersonDataScript> dataScripts;

    [SerializeField] private GameObject inventoryPanel;

    private const string Raycast_ID = "raycastPoint";
    private const string LookPoint_ID = "lookFreePoint";
    private const string OtherPersons_ID = "otherPersons";
    private const string FirstPersons_ID = "firstPerson";
    private const string InventoryPanel_ID = "inventoryPanel";
    private const string InventoryUI_ID = "inventoryUI";
    private const string EquipmentUI_ID = "equipmentUI";
    private const string PersonTarget_ID = "personTarget";

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GameSceneInstaller>().FromInstance(this).AsSingle();
        
        BindTransformCameraSystem();
        BindInputCamera();
        BindCharacterSwitch();
        BindPrefabFirstPerson();
        BindPrefabOtherPersons();
        BindInventory();
    }
     
    public async void Initialize()
    {
        var personFactory  = Container.Resolve<SpawnFirstPerson>();
        personFactory.SetPointSpawn(myPersonStartPoint.position);
        personFactory.LoadPerson();

        var personsFactory = Container.Resolve<IPersonFactory>(); 
        await personsFactory.LoadPersonsAsync();
        for(int i = 0; i < points.Count; i++) 
        {
            if (dataScripts[i] != null)
                personsFactory.SetPointsSpawn(points[i].transformPoint.position, dataScripts[i]);
        }
    }
    
    private void BindInventory()
    {
        // Bind InventoryUI with an identifier
        Container.Bind<IInventoryUI<int>>().WithId(InventoryUI_ID).To<InventoryUI>().FromInstance(inventoryUI).AsSingle();

        // Bind EquipmentUI with an identifier
        Container.Bind<IInventoryUI<int>>().WithId(EquipmentUI_ID).To<EquipmentUI>().FromInstance(equipmentUI).AsSingle();

        Container.BindInterfacesAndSelfTo<InventoryController>().FromNew().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<EquipmentController>().FromNew().AsSingle().NonLazy(); 
        
        Container.Bind<EquipmentPerson>().FromNew().AsTransient().NonLazy();
        Container.Bind<InventoryPerson>().FromNew().AsTransient().NonLazy();
         
        Container.Bind<GameObject>().WithId(InventoryPanel_ID).FromInstance(inventoryPanel); 
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
        Container.BindInterfacesAndSelfTo<PersonFactory>().AsSingle().NonLazy();
        Container.Bind<AssetReferenceGameObject>().WithId(OtherPersons_ID).FromInstance(otherPersonsReference);
    }

    private void BindPrefabFirstPerson()
    {
        Container.Bind<AssetReferenceGameObject>().WithId(FirstPersons_ID).FromInstance(firsPersonsReference);
        Container.BindInterfacesAndSelfTo<SpawnFirstPerson>().AsSingle().NonLazy();
      
        Container.BindInterfacesAndSelfTo<PickUpPerson>().FromInstance(pickUpPerson).AsSingle();
        Container.Bind<Transform>().WithId(PersonTarget_ID).FromInstance(pickUpPerson.transform).AsSingle(); 
    }
     
}
