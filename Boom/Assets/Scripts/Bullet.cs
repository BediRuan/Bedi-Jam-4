using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D bulletRigidbody;
    public float speed = 500f;
    public float lifetime = 10f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TeleportOnlyEnemy teleportOnlyEnemy = collision.gameObject.GetComponent<TeleportOnlyEnemy>();
        if (teleportOnlyEnemy != null)
        {
            teleportOnlyEnemy.MakeVulnerable();
            Destroy(gameObject); // Destroy the bullet
            return; // Exit to prevent double destruction
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Assuming all enemies have a method to handle their destruction properly
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.DestroyEnemy();
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }
}
