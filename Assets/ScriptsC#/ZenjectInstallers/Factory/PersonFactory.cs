
using System.Threading.Tasks;
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
    private GameObject _otherPerson;

    public PersonFactory(DiContainer diContainer, 
        [Inject(Id = "otherPersons")]AssetReferenceGameObject otherPersonsReference)
    {
        this.diContainer = diContainer;
        this.otherPersonsReference = otherPersonsReference;
    }
    public void Dispose()
    {
        if (_otherPerson == null) return;
        Addressables.Release(_otherPerson);
    }
    public void SetPointsSpawn(Vector3 point)
    {
        if (otherPersonOpHandle.Status == AsyncOperationStatus.Succeeded)
        {
            if(_otherPerson != null)
                diContainer.InstantiatePrefab(_otherPerson, point, Quaternion.identity, null);
        }  
    }
    public async Task LoadPersonsAsync()
    {
        if (!otherPersonsReference.RuntimeKeyIsValid()) return;
        otherPersonOpHandle = Addressables.LoadAssetAsync<GameObject>(otherPersonsReference);
        _otherPerson = await otherPersonOpHandle.Task;
    } 
}
