using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The object to follow
    public Vector3 offset = new Vector3(0, 2, -5); // Distance from the target
    public float smoothSpeed = 0.125f; 

    void LateUpdate() // Use LateUpdate for camera to follow after object movement 
    {
       Vector3 desiredPosition = target.position + offset;
      
       Debug.Log("Target Position: " + target.position.ToString("F4"));


    }
}