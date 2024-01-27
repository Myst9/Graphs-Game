using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logic_dfs : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;

    public void addScore(int val)
    {
        playerScore += val;
        scoreText.text = playerScore.ToString();
    }
}
