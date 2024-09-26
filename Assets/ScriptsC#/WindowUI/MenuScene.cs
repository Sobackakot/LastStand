
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class MenuScene : MonoBehaviour
{   
    private SaveDataSystem personData;

    [Inject]
    private void Container(SaveDataSystem personData)
    {
        this.personData = personData;
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SaveGameButton()
    {
        personData.SaveData();
    } 
    public void LoadGameButton()
    { 
        personData.LoadData();
    }
}
