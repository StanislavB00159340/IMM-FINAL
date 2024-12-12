using UnityEngine;

public class RaycastwithRotation : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Position where bullets should spawn
    public float shootCooldown = 1f; // Cooldown time in seconds
     public AudioSource audioSource;

    private float lastShootTime; // Tracks the time of the last shot

    void Update()
    {
        // Check if the space key is pressed and the cooldown has passed
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Update the time of the last shot
        lastShootTime = Time.time;

        // Adjust the rotation by -90 degrees on the Y-axis
        Quaternion adjustedRotation = bulletSpawnPoint.rotation * Quaternion.Euler(0, -90, 0);

        // Instantiate the bullet at the spawn point with the adjusted rotation
        Instantiate(bulletPrefab, bulletSpawnPoint.position, adjustedRotation);
        
           audioSource.Play();
    }
}
