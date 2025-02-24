using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Function to be called when the button is pressed
    public void LoadScene()
    {
        // Load the next scene by adding 1 to the current scene's build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
