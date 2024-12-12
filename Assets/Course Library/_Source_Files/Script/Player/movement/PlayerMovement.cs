using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed variable to control the movement speed
    public float rotationSpeed = 100f; // Rotation speed for left and right
    private Rigidbody rb;
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        // Get the Animator component
        animator = GetComponent<Animator>();

        // Freeze rotation on the X and Z axes to prevent falling over
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    void Update()
    {
        // Get input from the WASD or arrow keys
        float horizontalInput = Input.GetAxis("Horizontal"); // Rotation input
        float verticalInput = Input.GetAxis("Vertical"); // Forward/backward movement input

        // Rotate the player in place
        if (Mathf.Abs(horizontalInput) > 0)
        {
            transform.Rotate(0, horizontalInput * rotationSpeed * Time.deltaTime, 0);
        }

        // Move the player forward and backward
        Vector3 forwardMovement = transform.forward * (verticalInput * speed * Time.deltaTime);
        rb.MovePosition(rb.position + forwardMovement);

        // Update the animation based on movement direction
        UpdateAnimation(horizontalInput, verticalInput);
    }

    void UpdateAnimation(float horizontal, float vertical)
    {
        if (vertical > 0)
        {
            animator.Play("forward");
        }
        else if (vertical < 0)
        {
            animator.Play("Down");
        }
        else
        {
            animator.Play("Idle");
        }
    }
}
