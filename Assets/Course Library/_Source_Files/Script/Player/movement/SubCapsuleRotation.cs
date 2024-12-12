using UnityEngine;

public class SubCapsuleRotation : MonoBehaviour
{
    public float speed = 20f; // Speed variable to control the movement speed
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Freeze rotation on the X and Z axes to prevent falling over
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // Get input from the WASD or arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a movement direction vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the player using Rigidbody for physics-based movement
        rb.MovePosition(rb.position + movement * (speed * Time.deltaTime));

        // Rotate the player to face the movement direction with a 90-degree offset
        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Apply a 90-degree offset around the Y-axis
            Quaternion offsetRotation = Quaternion.Euler(0, -90, 0);
            rb.MoveRotation(targetRotation * offsetRotation);
        }
    }
}