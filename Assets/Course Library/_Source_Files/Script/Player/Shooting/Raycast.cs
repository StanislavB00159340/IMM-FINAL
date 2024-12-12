using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Position where bullets should spawn
    public float bulletSpeed = 20f; // Speed of the bullet

    private Vector3 lastPosition; // To track the player's previous position
    private Vector3 movementDirection; // Direction the player is moving

    void Start()
    {
        // Initialize the last position
        lastPosition = transform.position;
    }

    void Update()
    {
        // Calculate the movement direction based on position change
        movementDirection = (transform.position - lastPosition).normalized;
        lastPosition = transform.position;

        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Ensure there's a movement direction to shoot towards
        if (movementDirection != Vector3.zero)
        {
            // Apply velocity to the bullet based on movement direction
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = movementDirection * bulletSpeed;
            }
        }
    }
}
