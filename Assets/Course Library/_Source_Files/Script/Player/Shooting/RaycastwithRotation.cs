using UnityEngine;

public class RaycastwithRotation : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // Position where bullets should spawn

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
{
    // Adjust the rotation by -90 degrees on the Y-axis
    Quaternion adjustedRotation = bulletSpawnPoint.rotation * Quaternion.Euler(0, -90, 0);

    // Instantiate the bullet at the spawn point with the adjusted rotation
    Instantiate(bulletPrefab, bulletSpawnPoint.position, adjustedRotation);
}
} 