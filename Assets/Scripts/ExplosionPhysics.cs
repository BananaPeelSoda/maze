using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f; // Player's health
    public float explosionForce = 1000f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion
    public float upwardsModifier = 1f; // Modify how much force goes upwards
    public GameObject deathEffectPrefab; // Optional, a visual effect for death (explosion)

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody attached to the player
    }

    void Update()
    {
        // For demonstration, we reduce health over time to simulate damage
        if (health > 0)
        {
            health -= Time.deltaTime * 10f; // Example of health decreasing over time
        }

        // When health reaches 0, trigger explosion physics
        if (health <= 0f)
        {
            Explode();
            health = 0f; // Ensure health doesn't go negative
        }
    }

    // Function to handle the explosion effect
    void Explode()
    {
        // Play a death effect (optional)
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }

        // Apply explosion force to the player's Rigidbody
        if (rb != null)
        {
            // Add an explosion force in all directions
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
        }

        // Optionally, disable the player object after explosion
        // This line will destroy the player object after a short delay
        Destroy(gameObject, 0.5f);
    }

    // Function to reduce health (you can call this from other scripts to damage the player)
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Explode();
            health = 0f;
        }
    }
}
