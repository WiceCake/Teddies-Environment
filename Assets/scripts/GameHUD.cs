using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHUD : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text element for the timer
    public Text objectivesText; // Reference to the UI Text element for the objectives
    public Text currentObjectiveText; // Reference to the UI Text element for the current objective
    public Text dissappearingText; // Reference to the UI Text element for the dissappearing text
    public Image dissappearingImage; // Reference to the UI Image element for the dissappearing image
    public float gameDuration = 300f; // Total game time in seconds
    public float dissappearingTextDuration = 3f; // Duration to show the dissappearing text

    private float remainingTime;
    private int totalObjectives;
    public int collectedObjectives; // Make this public to access it from CharacterCollision
    private bool isGamePaused = false;
    private float dissappearingTextTimer;

    void Start()
    {
        remainingTime = gameDuration;
        dissappearingTextTimer = dissappearingTextDuration;
        ObjectiveManager objectiveManager = FindObjectOfType<ObjectiveManager>();
        if (objectiveManager != null)
        {
            totalObjectives = objectiveManager.itemPrefabs.Length;
        }
        else
        {
            totalObjectives = 5; // Default to 5 if ObjectiveManager is not found
        }
        collectedObjectives = 0; // Initialize to 0
        UpdateObjectivesText();
        UpdateCurrentObjectiveText("Find the first item");
        dissappearingText.gameObject.SetActive(true); // Make sure the dissappearing text is initially visible
        dissappearingImage.gameObject.SetActive(true); // Make sure the dissappearing image is initially visible
    }

    void Update()
    {
        if (!isGamePaused && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            // Handle dissappearing text and image
            if (dissappearingTextTimer > 0)
            {
                dissappearingTextTimer -= Time.deltaTime;
                if (dissappearingTextTimer <= 0)
                {
                    dissappearingText.gameObject.SetActive(false); // Hide the text after the duration
                    dissappearingImage.gameObject.SetActive(false); // Hide the image after the duration
                }
            }
        }
        else if (remainingTime <= 0 && !isGamePaused)
        {
            remainingTime = 0;
            PauseGame();
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateObjectives(int collected)
    {
        collectedObjectives = collected;
        UpdateObjectivesText();
        CheckWinCondition();
    }

    public void IncrementCollectedObjectives()
    {
        collectedObjectives++;
        UpdateObjectivesText();
        CheckWinCondition();
    }

    void UpdateObjectivesText()
    {
        objectivesText.text = "Items Collected: " + collectedObjectives + " of " + totalObjectives;
    }

    public void UpdateCurrentObjectiveText(string objectiveName)
    {
        currentObjectiveText.text = "Find the: " + objectiveName;
    }

    void PauseGame()
    {
        isGamePaused = true;
        Time.timeScale = 0;
        // Optional: Display a game over or pause menu
        Debug.Log("Game Paused. Time's up!");
    }

    // Optional: Add a method to resume the game if needed
    public void ResumeGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        // Hide the game over or pause menu if displayed
        Debug.Log("Game Resumed");
    }

    void CheckWinCondition()
    {
        if (collectedObjectives >= totalObjectives)
        {
            // Switch to the scene with index 1
            SceneManager.LoadScene(1);
        }
    }
}
