using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chapterselect : MonoBehaviour
{
    public string cutsceneSceneName = "story1";
    public string cutsceneSceneName2 = "story2";
    public string cutsceneSceneName3 = "story3";

    public void Chapter1()
    {
        // Check if the cutscene has been played before
        if (!PlayerPrefs.HasKey("story1"))
        {
            // If not played, play the cutscene
            PlayerPrefs.SetInt("story1", 1);
            PlayerPrefs.Save(); // Save the preference

            // Load the cutscene scene
            SceneManager.LoadScene(cutsceneSceneName);
        }
        else
        {
            // The cutscene has been played before, proceed with your main game logic
            // For example, load the main game scene
            SceneManager.LoadScene("try");
        }
    }
    public void Chapter1_game()
    {
        SceneManager.LoadScene("try");
    }

    public void Chapter2()
    {
        // Check if the cutscene has been played before
        if (!PlayerPrefs.HasKey("story2"))
        {
            // If not played, play the cutscene
            PlayerPrefs.SetInt("story2", 1);
            PlayerPrefs.Save(); // Save the preference

            // Load the cutscene scene
            SceneManager.LoadScene(cutsceneSceneName2);
        }
        else
        {
            // The cutscene has been played before, proceed with your main game logic
            // For example, load the main game scene
            SceneManager.LoadScene("DFS1");
        }
    }

    public void Chapter2_game()
    {
        SceneManager.LoadScene("DFS1");
    }

    public void Chapter3()
    {
        SceneManager.LoadScene("Dhanan");
    }

    public void Chapter4()
    {
        // Check if the cutscene has been played before
        if (!PlayerPrefs.HasKey("story3"))
        {
            // If not played, play the cutscene
            PlayerPrefs.SetInt("story3", 1);
            PlayerPrefs.Save(); // Save the preference

            // Load the cutscene scene
            SceneManager.LoadScene(cutsceneSceneName3);
        }
        else
        {
            // The cutscene has been played before, proceed with your main game logic
            // For example, load the main game scene
            SceneManager.LoadScene("ford");
        }
    }

    public void Chapter4_game()
    {
        SceneManager.LoadScene("ford");
    }

    public void Gb_mm()
    {
        SceneManager.LoadScene("starts");
    }
}
