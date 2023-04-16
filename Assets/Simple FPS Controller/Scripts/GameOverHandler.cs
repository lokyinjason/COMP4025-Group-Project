using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    // Set a variable of audio source
    public AudioSource gameOverSound; 

    private void Start()
    {
        gameOverCanvas.enabled = false;
    }

    public void HandleGameOver()
    {
        // Play the sound effect when the game is over
        gameOverSound.Play();

        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
