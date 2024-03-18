using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnlyEnemy : MonoBehaviour
{
    public bool isVulnerable = false;

    public void MakeVulnerable()
    {
        isVulnerable = true;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isVulnerable && (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("TeleportOnlyEnemy")))
        {
            Enemy thisEnemy = GetComponent<Enemy>();
            if (thisEnemy != null)
            {
                thisEnemy.DestroyEnemy(); // Destroy self
            }

            Enemy collidedEnemy = collision.gameObject.GetComponent<Enemy>();
            if (collidedEnemy != null)
            {
                collidedEnemy.DestroyEnemy(); // Destroy the enemy it collided with
            }
        }
    }
}
