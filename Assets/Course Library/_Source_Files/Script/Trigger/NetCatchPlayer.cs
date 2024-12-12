using UnityEngine;

public class NetCatchPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object that collided has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the player's position to (0, 0, 0)
            collision.gameObject.transform.position = Vector3.zero;

            // Optionally, reset velocity if the player has a Rigidbody component
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                playerRigidbody.linearVelocity = Vector3.zero;
                playerRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}
