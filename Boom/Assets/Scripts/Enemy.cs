using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRigidBody;
    public AudioClip explosionSound;
    public GameObject destructionParticlesPrefab;
    public float speed;
    public GameObject hiddenImage;
    public GameObject explosionPlayer;

    private AudioSource audioSource;

    public GameObject speedPowerUpPrefab;
    public GameObject radiusPowerUpPrefab;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        transform.Rotate(0, 0, Random.Range(0, 360));
        enemyRigidBody.AddForce(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(hiddenImage, transform.position, Quaternion.identity);
            Destroy(collision.gameObject); // Destroy the player

            FindObjectOfType<GameManager>().ShowRestartButton(); // Show restart button
        }
        else if (collision.gameObject.tag == "Wall")
        {
            enemyRigidBody.AddForce((-transform.up) * speed * 3);
        }
        else if (collision.gameObject.tag == "Bullet" && !gameObject.CompareTag("TeleportOnlyEnemy"))
        {
            DestroyEnemy();
        }
    }

    public void DestroyEnemy()
    {
        // Power-up drop chance
        if (Random.Range(0f, 1f) < 0.2f) // 20% chance to drop a power-up
        {
            GameObject powerUpPrefab = Random.Range(0f, 1f) < 0.5f ? speedPowerUpPrefab : radiusPowerUpPrefab;
            Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        }

        if (explosionPlayer != null)
        {
            Instantiate(explosionPlayer, transform.position, Quaternion.identity);
        }
        if (destructionParticlesPrefab != null)
        {
            Instantiate(destructionParticlesPrefab, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

