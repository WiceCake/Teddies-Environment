using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform headBone; // The transform representing the head bone
    public float mouseSensitivity = 100f;
    public float verticalLookLimit = 80f;
    public float initialDownwardAngle = 15f; // Initial downward angle

    private float xRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        xRotation = -initialDownwardAngle; // Set the initial downward angle
    }

    void LateUpdate() // Use LateUpdate so the camera follows after the body
    {
        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -verticalLookLimit, verticalLookLimit);

        // Follow the head bone (with rotation)
        transform.position = headBone.position;
        transform.rotation = headBone.rotation * Quaternion.Euler(xRotation, 0f, 0f);

        // Apply additional rotation to the body
        headBone.parent.Rotate(Vector3.up * mouseX);

        // Apply vertical look to the head bone
        headBone.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
