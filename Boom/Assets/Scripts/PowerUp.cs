using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType { Speed, Radius }
    public PowerUpType type;
    public float duration = 8f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                if (type == PowerUpType.Speed)
                {
                    player.ActivateSpeedBoost(duration);
                }
                else if (type == PowerUpType.Radius)
                {
                    player.ActivateRadiusBoost(duration);
                }
                Destroy(gameObject); // Destroy the power-up
            }
        }
    }
}
