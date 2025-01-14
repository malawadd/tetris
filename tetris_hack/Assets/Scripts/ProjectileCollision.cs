using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosionEffect; // Assign FX_Explosion prefab in the Inspector
    public float explosionDuration = 2f; // Duration to let the explosion effect play

    void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile hits an asteroid
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Trigger explosion effect
            PlayExplosion(collision.gameObject);

            // Destroy the asteroid
            Destroy(collision.gameObject);

            // Destroy the projectile immediately
            Destroy(gameObject);
        }
    }

    private void PlayExplosion(GameObject asteroid)
{
    // Instantiate explosion effect at the asteroid's position
    GameObject explosion = Instantiate(explosionEffect, asteroid.transform.position, Quaternion.identity);

    // Ensure the explosion effect is not parented to the asteroid
    explosion.transform.parent = null;

    // Start the scaling effect
    StartCoroutine(ScaleExplosion(explosion));

    // Destroy the explosion effect after it finishes playing
    Destroy(explosion, explosionDuration);
}

private System.Collections.IEnumerator ScaleExplosion(GameObject explosion)
{
    float elapsedTime = 0f;
    float scaleDuration = explosionDuration; // Time for the scale effect
    Vector3 startScale = explosion.transform.localScale * 20f; // Start 20x larger
    Vector3 endScale = Vector3.zero; // Shrink to nothing

    // Apply scaling over time
    while (elapsedTime < scaleDuration)
    {
        float t = elapsedTime / scaleDuration;
        explosion.transform.localScale = Vector3.Lerp(startScale, endScale, t);
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    // Ensure it reaches the end scale
    explosion.transform.localScale = endScale;
}

}
