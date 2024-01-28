using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTimer_dfs : MonoBehaviour
{
    public float sceneDuration = 10f;
    public GameObject gameOverPanel;
    public Logic_dfs logicScript; 
    public Text congratsText; 

    private float timer = 0f;
    private bool gameIsOver = false;
    public string sceneName;

    void Start()
    {
        gameOverPanel.SetActive(false);
        congratsText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!gameIsOver)
        {
            timer += Time.deltaTime;
            if (timer >= sceneDuration)
            {
                GameOver();
            }
        }

        if (gameIsOver && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)))
        {
            FindObjectOfType<LevelManger>().changeScene();
        }
    }

    void GameOver()
    {
        gameIsOver = true;
        gameOverPanel.SetActive(true);
        int finalScore = logicScript.playerScore * 100;
        congratsText.text = " You won " + finalScore.ToString() + " points!";
        congratsText.gameObject.SetActive(true);
    }
}
