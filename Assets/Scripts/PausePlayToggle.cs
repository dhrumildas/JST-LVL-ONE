using UnityEngine;
using UnityEngine.UI;

public class PausePlayToggle : MonoBehaviour
{
    public Sprite pauseSprite;        // Non-pressed pause sprite
    public Sprite pressedPauseSprite; // Pressed pause sprite
    public Sprite playSprite;         // Non-pressed play sprite
    public Sprite pressedPlaySprite;  // Pressed play sprite
    public GameObject pauseText;      // Assign the "PAUSED" text object in the Inspector

    private Image buttonImage;
    private Button button;
    private bool isPaused = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
        UpdateButtonSprites(); // Set initial sprites
    }

    void Update()
    {
        // Listen for the Escape key press to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void OnButtonClick()
    {
        TogglePause();
    }

    void TogglePause()
    {
        isPaused = !isPaused; // Toggle between paused and playing
        UpdateButtonSprites();

        if (isPaused)
        {
            Pause();
        }
        else
        {
            ResumeGame();
        }
    }

    void Pause()
    {
        Time.timeScale = 0; // Pause the game
        pauseText.SetActive(true); // Show the "PAUSED" text
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        pauseText.SetActive(false); // Hide the "PAUSED" text
    }

    void UpdateButtonSprites()
    {
        if (isPaused)
        {
            buttonImage.sprite = playSprite;
            SpriteState spriteState = button.spriteState;
            spriteState.pressedSprite = pressedPlaySprite;
            button.spriteState = spriteState;
        }
        else
        {
            buttonImage.sprite = pauseSprite;
            SpriteState spriteState = button.spriteState;
            spriteState.pressedSprite = pressedPauseSprite;
            button.spriteState = spriteState;
        }
    }
}
