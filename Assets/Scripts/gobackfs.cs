using UnityEngine;
using UnityEngine.SceneManagement;

public class Gobackfs : MonoBehaviour
{
    private bool isPaused = false;
    private bool cursorLocked = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Only allow 3D rotation if the game is not paused
        if (!isPaused)
        {
            // Rotate logic or other non-paused functionality here
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;
            Cursor.visible = true; // Show the cursor
            cursorLocked = false; // Unlock the cursor
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f;
            Cursor.visible = false; // Hide the cursor
            cursorLocked = true; // Lock the cursor
        }

        // Lock or unlock the cursor's movement
        Cursor.lockState = cursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
    }

    void OnGUI()
    {
        if (isPaused)
        {
            // Display pause menu window
            GUI.Window(0, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), PauseMenuWindow, "Pause Menu");
        }
    }

    void PauseMenuWindow(int windowID)
    {
        if (GUI.Button(new Rect(50, 50, 200, 40), "Resume"))
        {
            // Resume the game
            TogglePause();
        }

        if (GUI.Button(new Rect(50, 100, 200, 40), "Quit"))
        {
            // Load another scene
            SceneManager.LoadScene("chapters");
        }
    }
}

