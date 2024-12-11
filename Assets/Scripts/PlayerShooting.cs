using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint; // Assign the gun's shooting point
    public ParticleSystem muzzleFlash; // Assign the particle system in the inspector
    public float shootForce = 20f;
    public float shootCooldown = 0.5f; // Time in seconds between shots

    private float lastShotTime = 0f;

    void Start()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Stop(); // Ensure the particle system is not playing at the start
        }
    }

    void Update()
    {
        AlignGunWithCamera(); // Ensure the gun follows the camera's rotation

        if (Input.GetButtonDown("Fire1") && Time.time >= lastShotTime + shootCooldown) // Left mouse click with cooldown check
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void AlignGunWithCamera()
    {
        // Logic for aligning the gun with the camera (implement as needed)
    }

    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play(); // Play the particle system
        }

        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(shootPoint.forward * shootForce, ForceMode.Impulse);
        Destroy(projectile, 1f);
    }
}

// Separate script for projectile behavior
public class Projectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}

