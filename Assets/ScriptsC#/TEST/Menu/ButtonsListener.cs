
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsListener  
{   
    public ButtonsListener(MoveblePerson movePerson) 
    { 
        this.movePerson = movePerson;
    }

    private MoveblePerson movePerson;
    public void StartButton()
    {
        Debug.Log(movePerson.ShowText());
        SceneManager.LoadScene(3);
    }
     
    public void ExitButton()
    {
#if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
#else
Application.Quit(2);
#endif
    }
}
