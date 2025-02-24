using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered the trigger is on the "Player" layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player entered trigger"); // Add this line
            // Load the next scene based on the build index
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Something else entered trigger: " + collision.gameObject.name); // Add this line to see if another object is triggering it
        }
    }
}
