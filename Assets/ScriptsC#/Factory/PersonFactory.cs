
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

public class PersonFactory : IPersonFactory, IDisposable
{
    private AssetReferenceGameObject otherPersonsReference;
    private AsyncOperationHandle<GameObject> otherPersonOpHandle;
    private readonly DiContainer diContainer; 
    private GameObject _otherPerson;

    public PersonFactory(DiContainer diContainer,
        [Inject(Id = "otherPersons")]AssetReferenceGameObject otherPersonsReference)
    {
        this.diContainer = diContainer;
        this.otherPersonsReference = otherPersonsReference;
    }
   
    public void SetPointsSpawn(Vector3 point, PersonDataScript personData)
    {
        if (otherPersonOpHandle.Status == AsyncOperationStatus.Succeeded)
        {
            if(_otherPerson != null)
            {
                // Создаем экземпляр префаба в заданной точке
                GameObject person = diContainer.InstantiatePrefab(_otherPerson, point, Quaternion.identity, null);
                // Назначаем PersonDataScript созданному объекту
                PickUpPerson pickPerson = person.GetComponent<PickUpPerson>(); 
                pickPerson.personData = personData;
            }     
        }  
    }
    public async Task LoadPersonsAsync()
    {
        if (!otherPersonsReference.RuntimeKeyIsValid()) return;
        otherPersonOpHandle = Addressables.LoadAssetAsync<GameObject>(otherPersonsReference);
        _otherPerson = await otherPersonOpHandle.Task;
    }

    public void Dispose()
    {
        if (_otherPerson == null) return;
        Addressables.Release(_otherPerson);
    }
}
