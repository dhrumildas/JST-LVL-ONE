using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneZero : MonoBehaviour
{
    public void LoadScene()
    {
        // Load the scene with build index 0
        SceneManager.LoadScene(0);
    }
}
