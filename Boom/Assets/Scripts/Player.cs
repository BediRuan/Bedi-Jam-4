using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float bulletLifetime = 4f;
    private Vector2 lastMovementDirection;

    public AudioClip shootSound;
    public AudioClip teleportSound;
    private AudioSource audioSource;

    private GameObject currentBullet;

    public float shootCooldown = 2f; // 2 seconds cooldown for shooting
    private float shootTimer = 0f; // Timer to track cooldown

    public Vector2 direction;
    public Rigidbody2D rb;
    public float speed = 2f;

    private float defaultSpeed;
    public float teleportKillRadius = 1.8f;
    private float defaultRadius;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        defaultSpeed = speed;
        defaultRadius = teleportKillRadius;
    }

    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            movementInput.Normalize();
            lastMovementDirection = movementInput;
        }

        // Increment the shoot timer
        shootTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentBullet == null && shootTimer >= shootCooldown)
            {
                ShootBullet();
                shootTimer = 0f; // Reset the shoot timer after shooting
            }
            else if (currentBullet != null)
            {
                TeleportToBullet();
            }
        }

        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        //Move the player
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    void ShootBullet()
    {
        Vector3 bulletSpawnPosition = transform.position;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = lastMovementDirection * bulletSpeed;

        currentBullet = bullet;
        Destroy(bullet, bulletLifetime);
        PlaySound(shootSound);
    }

    void TeleportToBullet()
    {
        if (currentBullet != null)
        {
            Vector3 teleportPosition = currentBullet.transform.position;
            transform.position = teleportPosition;
            Destroy(currentBullet);
            currentBullet = null;
            PlaySound(teleportSound);
            DestroyNearbyEnemies(teleportPosition, 1.8f);
        }
    }

    void DestroyNearbyEnemies(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy") || hitCollider.CompareTag("TeleportOnlyEnemy"))
            {
                Enemy enemyScript = hitCollider.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.DestroyEnemy();
                }
            }
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ActivateSpeedBoost(float duration)
    {
        StopCoroutine("SpeedBoostCoroutine"); 
        speed *= 2; 
        StartCoroutine(SpeedBoostCoroutine(duration)); 
    }

    IEnumerator SpeedBoostCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
    }

    public void ActivateRadiusBoost(float duration)
    {
        StopCoroutine("RadiusBoostCoroutine"); // Use the name of the coroutine as a string
        teleportKillRadius *= 2; 
        StartCoroutine(RadiusBoostCoroutine(duration)); // Pass duration correctly
    }

    IEnumerator RadiusBoostCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        teleportKillRadius = defaultRadius;
    }
}
