using UnityEngine;

public class GameCloser : MonoBehaviour
{
    void Start()
    {
        // Schedule the CloseGame method to be called after 20 seconds
        Invoke("CloseGame", 30f);
    }

    void CloseGame()
    {
        // Close the game
        Application.Quit();

        // Note: Application.Quit() may not work in the Unity Editor, but it should work in a standalone build.
    }
}


