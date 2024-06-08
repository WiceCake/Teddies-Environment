using UnityEngine;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public GameObject[] itemPrefabs; // Array of item prefabs
    public Transform[] spawnPoints; // Array of spawn points
    public int totalObjectives = 5; // Total number of objectives to spawn

    private List<GameObject> spawnedItems = new List<GameObject>();
    private int nextItemIndex = 0; // Index for the next item to be spawned
    private int collectedObjectives = 0; // Number of collected objectives
    private GameHUD gameHUD;

    void Start()
    {
        gameHUD = FindObjectOfType<GameHUD>();
        SpawnNewItem();
    }

    public void ItemCollected(GameObject item)
    {
        spawnedItems.Remove(item);
        Destroy(item);
        collectedObjectives++;
        gameHUD.UpdateObjectives(collectedObjectives);
        CheckAllItemsCollected();

        if (collectedObjectives < totalObjectives)
        {
            SpawnNewItem();
        }
    }

    void SpawnNewItem()
    {
        if (nextItemIndex < itemPrefabs.Length && nextItemIndex < spawnPoints.Length)
        {
            int spawnIndex = nextItemIndex; // Use the same index for spawn point and item
            GameObject newItem = Instantiate(itemPrefabs[nextItemIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
            spawnedItems.Add(newItem);
            nextItemIndex++;

            // Update the current objective text
            string itemName = itemPrefabs[nextItemIndex - 1].name;
            gameHUD.UpdateCurrentObjectiveText(itemName);
        }
    }

    void CheckAllItemsCollected()
    {
        if (collectedObjectives >= totalObjectives)
        {
            // Implement the logic to open the door or finish the game
            Debug.Log("All items collected! Game Over.");
        }
    }
}
