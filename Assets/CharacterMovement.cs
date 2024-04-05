using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb; 
    public float speed = 5f;
    public float jumpForce = 5f;
    public float torqueForce = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()  // Use FixedUpdate for physics updates
    {
        // Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.fixedDeltaTime;
        rb.AddForce(movement, ForceMode.Impulse); 
        rb.AddTorque(transform.right * horizontalInput * torqueForce); 

        // Jump
        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Simple check if the character is touching the ground
    bool IsGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f); 
    }
}