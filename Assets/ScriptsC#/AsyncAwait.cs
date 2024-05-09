
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwait : MonoBehaviour
{
    private CancellationTokenSource token;

    private void OnEnable()
    {
        token = new CancellationTokenSource();
        Debug.Log(" task , on enable");

        // Start the work in a separate task
        Task.Run(DoWork);
    }

    private void OnDisable()
    {
        Debug.Log(" task , on disable , task cancel");

        // Cancel the task when the script is disabled
        token.Cancel();
    }
    private async void Start()
    {
        Task trick1Task = PerformTrick("Card Trick");
        Task trick2Task = PerformTrick("Coin Trick");
        // Await the completion of each trick
        await trick1Task;
        await trick2Task;
    } 
    private async Task PerformTrick(string trickName)
    {
        // Simulate the time it takes to set up the trick
        await Task.Delay(3000); // 3 seconds 
    }
    private async void DoWork()
    {
        Debug.Log(" task , do work");
        await Task.Run(() =>
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("Hello");
                if (token.IsCancellationRequested)
                {
                    return;
                }
            }
        }, token.Token);

        if (token.IsCancellationRequested)
        {
            Debug.Log("task was cancelled.");
            return; // further code will not be executed
        }

        // Code to be executed after the task completes successfully
        Debug.Log("task completed successfully.");
    }
   
}
