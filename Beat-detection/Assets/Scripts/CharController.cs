using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 5.0f; // Movement speed
    public float jumpForce = 7.0f; // Jump force
    public LayerMask groundLayer; // Ground layer to determine what is ground

    private Rigidbody rb; // Rigidbody component for physics
    private bool isGrounded; // Boolean to check if the player is grounded

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
    }

    void Update()
    {
        Move(); // Handle movement
        Jump(); // Handle jumping
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.MovePosition(transform.position + movement * speed * Time.deltaTime); // Move the Rigidbody to new position

        Debug.Log($"Movement Vector: {movement}"); // Log the movement vector for debugging
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // Check if Jump button is pressed and the player is grounded
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Add an upward force for jumping
            Debug.Log("Jumping"); // Log jumping for debugging
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) != 0) // Check if the collision is with the ground layer
        {
            isGrounded = true; // Set grounded to true
            Debug.Log("Grounded"); // Log grounded for debugging
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((groundLayer.value & (1 << collision.gameObject.layer)) != 0) // Check if the collision is leaving the ground layer
        {
            isGrounded = false; // Set grounded to false
            Debug.Log("Not Grounded"); // Log not grounded for debugging
        }
    }
}
