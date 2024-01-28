using UnityEngine;
using UnityEngine.SceneManagement;

public class goback : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause state
            isPaused = !isPaused;

            // Show/hide the pause menu
            if (isPaused)
                Time.timeScale = 0f; // Pause the game
            else
                Time.timeScale = 1f; // Resume the game
        }
    }

    void OnGUI()
    {
        // Display the pause menu if the game is paused
        if (isPaused)
        {
            // Create a small window
            GUI.Window(0, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 75, 300, 150), PauseMenuWindow, "Pause Menu");
        }
    }

    void PauseMenuWindow(int windowID)
    {
        // Display resume button
        if (GUI.Button(new Rect(50, 50, 200, 40), "Resume"))
        {
            // Resume the game
            isPaused = false;
            Time.timeScale = 1f;
        }

        // Display quit button
        if (GUI.Button(new Rect(50, 100, 200, 40), "Quit"))
        {
            // Load another scene (replace "YourSceneName" with the name of your desired scene)
            SceneManager.LoadScene("chapters");
        }
    }
}

