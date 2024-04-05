using UnityEngine;

public class CharacterControllerMovement : MonoBehaviour
{
    public CharacterController controller; 
    public float speed = 5f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float inputDeadzone = 0.1f; // Threshold for movement input 

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement with input deadzone
        if (Mathf.Abs(horizontalInput) > inputDeadzone || Mathf.Abs(verticalInput) > inputDeadzone) 
        {
            Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
            controller.Move(moveDirection * speed * Time.deltaTime);
        }

        // Gravity simulation 
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Reset y-velocity when grounded
        if (controller.isGrounded) 
        {
            velocity.y = 0f; 
        }

        // Jump
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity); 
        }
    }
}
