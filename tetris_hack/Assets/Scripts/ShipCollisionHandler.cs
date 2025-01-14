using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    public GameObject explosionEffect; // Assign FX_Explosion prefab in the Inspector
    public float explosionDelay = 1.5f; // Time to show explosion before ending the game
    public GameOverManager gameOverManager; // Reference to the GameOverManager

    private bool isGameOver = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && !isGameOver)
        {
            isGameOver = true;
            TriggerExplosion();
        }
    }

    private void TriggerExplosion()
    {
        // Instantiate the explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Hide the ship (disable mesh renderer or set inactive)
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Delay ending the game
        Invoke("EndGame", explosionDelay);
    }

    private void EndGame()
    {
        // Trigger the Game Over screen
        if (gameOverManager != null)
        {
            gameOverManager.GameOver();
        }

        // Destroy the ship
        Destroy(gameObject);
    }
}
