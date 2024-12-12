using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character; // Reference to the player's Transform
    public Vector3 offset = new Vector3(0, 50f, -90f); // Offset position relative to the player

    void LateUpdate()
    {
        if (character != null)
        {
            // Set the camera's position based on the player's position and the offset
            transform.position = character.position + offset;
        }
    }
}