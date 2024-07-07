
using System; 
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;

public class SpawnFirstPerson : IDisposable
{
    private AssetReferenceGameObject personReference;
    private AsyncOperationHandle<GameObject> personOpHandle;
    private DiContainer diContainer;
    private Vector3 pointn;
    private SpawnFirstPerson(DiContainer diContainer, 
        [Inject(Id = "firstPerson")]AssetReferenceGameObject personReference)
    {
        this.diContainer = diContainer;
        this.personReference = personReference;
    }
    public void SetPointSpawn(Vector3 pointn)
    {
        this.pointn = pointn;
    }
    public void LoadPerson()
    {
        personOpHandle = Addressables.LoadAssetAsync<GameObject>(personReference);
        personOpHandle.Completed += SpawnPerson;
    }
    private void SpawnPerson(AsyncOperationHandle<GameObject> personOpHandle)
    {
        if(personOpHandle.Status == AsyncOperationStatus.Succeeded)
        {
            diContainer.InstantiatePrefab(personOpHandle.Result, pointn, Quaternion.identity, null);
        }
    }
    public void Dispose()
    {
        personOpHandle.Completed -= SpawnPerson;
    }
}
