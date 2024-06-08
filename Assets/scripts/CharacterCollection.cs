using UnityEngine;

public class CharacterCollection : MonoBehaviour
{
    private ObjectiveManager objectiveManager;

    void Start()
    {
        objectiveManager = FindObjectOfType<ObjectiveManager>();
        Debug.Log("CharacterCollection script initialized");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Collectible"))
        {
            Debug.Log("Collectible item detected: " + other.gameObject.name);
            objectiveManager.ItemCollected(other.gameObject);
        }
    }
}
