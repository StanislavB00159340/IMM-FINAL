using UnityEngine;

public class EnemyShootLogic : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // The position where bullets are spawned
    public Transform player; // Reference to the player's transform
    public float shootInterval = 2f; // Interval between shots
    public float bulletSpeed = 10f; // Speed of the bullet

    private float shootTimer = 0f; // Timer to track the shooting interval

    void Update()
    {
        // Update the shoot timer
        shootTimer += Time.deltaTime;

        // Check if it's time to shoot
        if (shootTimer >= shootInterval)
        {
            ShootAtPlayer();
            shootTimer = 0f; // Reset the timer
        }
    }

    void ShootAtPlayer()
    {
        if (player == null || bulletPrefab == null || bulletSpawnPoint == null)
        {
            Debug.LogWarning("Missing references in EnemyShootLogic!");
            return;
        }

        // Store the player's position at the time of shooting
        Vector3 targetPosition = player.position;

        // Calculate the direction to the stored position
        Vector3 direction = (targetPosition - bulletSpawnPoint.position).normalized;

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(direction));

        // Add velocity to the bullet to make it move toward the stored position
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.linearVelocity = direction * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("Bullet prefab is missing a Rigidbody component!");
        }
    }
}
