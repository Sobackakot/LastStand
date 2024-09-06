
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuScene : MonoBehaviour
{   
    private PersonDataManager personData;

    [Inject]
    private void Container(PersonDataManager personData)
    {
        this.personData = personData;
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SaveGameButton()
    {

    } 
    public void LoadGameButton()
    { 

    }
}
