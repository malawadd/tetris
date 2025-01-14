using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // This function is called when the "Start" button is pressed
    public void StartGame()
    {
        // Load the game scene (replace "GameScene" with the actual scene name)
        SceneManager.LoadScene("Ship Flight");
    }

    // This function is called when the "Quit" button is pressed
    public void QuitGame()
    {
        // Logs a message in the editor for testing
        Debug.Log("Game Quit");

        // Exits the application (does not work in the editor)
        Application.Quit();
    }
}
