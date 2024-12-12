using UnityEngine;

public class folllowBullet : MonoBehaviour
{
    public Transform bullet; // Reference to the player's Transform

    void LateUpdate()
    {
            // Set the camera's position based on the player's position and the offset
            transform.position = bullet.position;
    }
}
