 
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller 
{
    [SerializeField] private RaycastPointFollow raycastPointFollow;
    [SerializeField] private CameraLookTarget cameraLookTarget;

    [SerializeField] private Transform myPersonStartPoint;
    [SerializeField] private GameObject myPersonPrefab;

    [SerializeField] private FollowCamera freePoint;

    [SerializeField] private PersonMoveControl personMoveControl;
     
    public override void InstallBindings()
    {
        InputControllerCamera();
    }
    private void InputControllerCamera()
    { 

        BindCameraInstaller();

        BindPrefabMyPerson();
    }

    private void BindCameraInstaller()
    {
        Container.BindInterfacesAndSelfTo<InputControllerCamera>().AsSingle().NonLazy();
        Container.Bind<RaycastPointFollow>().FromInstance(raycastPointFollow).AsSingle();
        Container.Bind<CameraLookTarget>().FromInstance(cameraLookTarget).AsSingle();
        Container.Bind<Camera>().FromInstance(cameraLookTarget.gameObject.GetComponent<Camera>()).AsSingle();
        Container.Bind<PersonMoveControl>().FromInstance(personMoveControl).AsSingle();
    }

    private void BindPrefabMyPerson()
    {
        PickUpPerson myPerson = Container.InstantiatePrefabForComponent<PickUpPerson>(myPersonPrefab, myPersonStartPoint.position, Quaternion.identity, null);
        Container.Bind<PickUpPerson>().FromInstance(myPerson).AsSingle();
        Container.Bind<Transform>().FromInstance(myPerson.transform).AsSingle();
        Container.Bind<FollowCamera>().FromInstance(freePoint).AsSingle();
    } 
}
