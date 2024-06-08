using UnityEngine;
using UnityEngine.UI;

public class GameHUD : MonoBehaviour
{
    public Text timerText; // Reference to the UI Text element for the timer
    public Text objectivesText; // Reference to the UI Text element for the objectives
    public Text currentObjectiveText; // Reference to the UI Text element for the current objective
    public float gameDuration = 300f; // Total game time in seconds

    private float remainingTime;
    private int totalObjectives;
    private int collectedObjectives;
    private bool isGamePaused = false;

    void Start()
    {
        remainingTime = gameDuration;
        ObjectiveManager objectiveManager = FindObjectOfType<ObjectiveManager>();
        if (objectiveManager != null)
        {
            totalObjectives = objectiveManager.itemPrefabs.Length;
        }
        collectedObjectives = 5;
        UpdateObjectivesText();
        UpdateCurrentObjectiveText("Find the first item");
    }

    void Update()
    {
        if (!isGamePaused && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();
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
    }

    void UpdateObjectivesText()
    {
        objectivesText.text = "Objectives: " + collectedObjectives + " / " + totalObjectives;
    }

    public void UpdateCurrentObjectiveText(string objectiveName)
    {
        currentObjectiveText.text = "Find the:  " + objectiveName;
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
}
