using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseText; // Assign the "PAUSED" text object in the Inspector
    private bool isPaused = false;

    public void PauseButtonClicked()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0; // Pause the game
        pauseText.SetActive(true); // Show the "PAUSED" text
        isPaused = true;
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        pauseText.SetActive(false); // Hide the "PAUSED" text
        isPaused = false;
    }
}
