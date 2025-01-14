using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.SceneManagement; // To reload the scene

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the panel
    public TMP_Text gameOverText;   // Reference to the TextMeshPro component for asteroid count
    public string mainSceneName = "Ship Flight"; // Name of the scene to reload (change as needed)
    public TMP_Text asteroidCountText;

    void Start()
    {
        // Ensure the game over screen is hidden at the start
        gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        // Show the game over screen
        gameOverPanel.SetActive(true);

        // Update the "Game Over" text
    if (gameOverText != null)
    {
        gameOverText.text = "Game Over!";
    }

    // Update the asteroid destroyed count text
    if (asteroidCountText != null)
    {
        asteroidCountText.text = "Asteroids Destroyed: " + ProjectileCollision.asteroidDestroyedCount;
    }
    }

    public void RestartGame()
    {
        // Reset the asteroid count
        ProjectileCollision.asteroidDestroyedCount = 0;

        // Reload the scene
        SceneManager.LoadScene(mainSceneName);
    }
}
