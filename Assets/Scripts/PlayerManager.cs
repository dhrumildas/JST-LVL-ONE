using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Add this for TextMeshPro

public class PlayerManager : MonoBehaviour
{
    public float restartDelay = 3f; // Delay before restarting the game
    public TextMeshProUGUI countdownText; // Reference to the Countdown text UI
    private Damageable damageable;
    private float countdownTime;

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        damageable.deathEvent.AddListener(OnPlayerDeath);
    }

    private void OnPlayerDeath()
    {
        // Start the countdown and restart process
        countdownTime = restartDelay;
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true);
        }
        InvokeRepeating("UpdateCountdown", 0f, 1f); // Update every second
        Invoke("RestartGame", restartDelay);
    }

    private void UpdateCountdown()
    {
        countdownTime -= 1f;
        if (countdownText != null)
        {
            countdownText.text = $"Respawning in {Mathf.Ceil(countdownTime)}s";
        }
    }

    private void RestartGame()
    {
        // Stop the countdown updates
        CancelInvoke("UpdateCountdown");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
