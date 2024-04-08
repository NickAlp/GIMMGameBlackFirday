using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25; // Set your desired damage amount in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet has collided with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the EnemyAi component of the collided enemy and apply damage
            EnemyAi enemy = collision.gameObject.GetComponent<EnemyAi>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            // Destroy the bullet on impact
            Destroy(gameObject);
        }
    }
}
