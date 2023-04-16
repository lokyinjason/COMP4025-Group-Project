using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void ReloadGame()
    {
        // Reload the current scene
        Debug.Log("Reloading game...");
        SceneManager.LoadScene(0);
        // Reset the time scale to 1
        Time.timeScale = 1;
        // Reset the cursor to be locked
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
