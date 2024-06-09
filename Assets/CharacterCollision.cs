using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    private GameHUD GameHUDCanvas;

    void Start()
    {
        GameHUDCanvas = FindObjectOfType<GameHUD>(); // Find the GameHUD in the scene
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Item")
        {
            Debug.Log("Item Collected");

            // Increase the collected objectives count
            GameHUDCanvas.UpdateObjectives(GameHUDCanvas.collectedObjectives + 1);

            // Optionally destroy the collected item
            Destroy(collisionInfo.gameObject);
        }
    }
}
