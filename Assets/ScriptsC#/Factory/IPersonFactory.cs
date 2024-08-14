

using System.Threading.Tasks;
using UnityEngine;

public interface IPersonFactory  
{
    Task LoadPersonsAsync();
    void SetPointsSpawn(Vector3 point, PersonDataScript data);
}
