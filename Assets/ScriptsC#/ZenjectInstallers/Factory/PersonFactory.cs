 
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

public class PersonFactory : IPersonFactory
{
    private AssetReferenceGameObject otherPersonsReference;
    private AsyncOperationHandle<GameObject> otherPersonOpHandle;
    private readonly DiContainer diContainer; 
    public Vector3 point { get; private set; }

    public PersonFactory(DiContainer diContainer, 
        [Inject(Id = "otherPersons")]AssetReferenceGameObject otherPersonsReference)
    {
        this.diContainer = diContainer;
        this.otherPersonsReference = otherPersonsReference;
    }
    public void Dispose()
    {
        otherPersonOpHandle.Completed -= OnCreateOtherPersonAsync;
    }
    public void SetPointsSpawn(Vector3 point)
    {
        this.point = point;
    }
    public void LoadPersons()
    {
        if (!otherPersonsReference.RuntimeKeyIsValid()) return; 
        otherPersonOpHandle = Addressables.LoadAssetAsync<GameObject>(otherPersonsReference);
        otherPersonOpHandle.Completed += OnCreateOtherPersonAsync;
    }
    public void OnCreateOtherPersonAsync(AsyncOperationHandle<GameObject> otherPerson)
    {
        if (otherPerson.Status == AsyncOperationStatus.Succeeded)
        {
            diContainer.InstantiatePrefab(otherPerson.Result, point, Quaternion.identity, null);
        }
    }
}
