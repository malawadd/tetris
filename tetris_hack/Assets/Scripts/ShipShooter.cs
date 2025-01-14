using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    public GameObject[] projectilePrefabs; // Array of shapes to shoot (assign in Inspector)
    public Transform firePoint;           // Where the projectiles spawn (assign in Inspector)
    public float fireForce = 20f;         // Speed of the projectile

    void Update()
    {
        // Detect right mouse button click
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Randomly select a shape to shoot
        int index = Random.Range(0, projectilePrefabs.Length);
        GameObject selectedProjectile = projectilePrefabs[index];

        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(selectedProjectile, firePoint.position, firePoint.rotation);

        // Add force to the projectile to "shoot" it
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * fireForce, ForceMode.Impulse);
        }

        // Destroy the projectile after 5 seconds to prevent clutter
        Destroy(projectile, 5f);
    }
}
