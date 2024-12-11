using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float fieldOfVision = 10f; // Distance the enemy can "see"
    public float followSpeed = 3f; // Speed at which the enemy follows the player

    private bool isTrackingPlayer = false;

    void Update()
    {
        // Check distance between enemy and player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // If the player is within the enemy's field of vision, start tracking
        if (distanceToPlayer <= fieldOfVision)
        {
            isTrackingPlayer = true;
        }

        // If tracking is active, move towards the player
        if (isTrackingPlayer)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Move the enemy towards the player's position
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * followSpeed * Time.deltaTime;

        // Optionally, rotate the enemy to face the player
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }
}
