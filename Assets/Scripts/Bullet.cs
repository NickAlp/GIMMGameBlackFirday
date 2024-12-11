using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Enemy" tag
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy GameObject
            Destroy(collision.gameObject);
        }

        // Destroy the projectile upon collision
        Destroy(gameObject);
    }
}
