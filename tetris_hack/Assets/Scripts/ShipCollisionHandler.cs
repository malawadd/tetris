using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    public GameObject explosionEffect; // Assign FX_Explosion prefab in the Inspector
    public float explosionDelay = 1.5f; // Time to show explosion before ending the game

    private bool isGameOver = false; // Prevent multiple triggers

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid") && !isGameOver)
        {
            isGameOver = true;
            TriggerExplosion();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Asteroid") && !isGameOver)
        {
            isGameOver = true;
            TriggerExplosion();
        }
    }

    private void TriggerExplosion()
    {
        // Instantiate the explosion effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // Hide the ship by disabling all renderers in its hierarchy
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = false;
        }

        // Disable the ship's collider to prevent further collisions
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // Destroy the ship after the explosion delay
        Invoke("EndGame", explosionDelay);
    }

    private void EndGame()
    {
        // Destroy the ship and handle game-over logic
        Destroy(gameObject);
        Debug.Log("Game Over!");
    }
}
