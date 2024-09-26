
using System; 
using UnityEngine.UI;
using Zenject;

public class ButtonsEvent : IInitializable, IDisposable
{   
    public ButtonsEvent(Button startButton, Button exitButton, ButtonsListener listener) 
    {
        this.startButton = startButton;
        this.exitButton = exitButton;
        this.listener = listener;
    }


    private readonly Button startButton;
    private readonly Button exitButton;
    private readonly ButtonsListener listener;
     
    public void Initialize()
    {
        startButton.onClick.AddListener(listener.StartButton);
        exitButton.onClick.AddListener(listener.ExitButton);
    }
    public void Dispose()
    {
        startButton.onClick.RemoveListener(listener.StartButton);
        exitButton.onClick.RemoveListener(listener.ExitButton);
    }
}
