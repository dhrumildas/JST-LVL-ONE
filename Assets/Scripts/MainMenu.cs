using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to be called when the "Start Game" button is pressed
    public void StartGame()
    {
        // Load the next scene by adding 1 to the current scene's build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Function to be called when the "Quit Game" button is pressed
    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
#if UNITY_EDITOR
        // If running in the Unity editor, stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
