using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public int playerScore = 0;
    public Text scoreText;
    static int Size = 9;     //Number of objects
    public Text[] alive = new Text[Size];
    public GameObject[] Players = new GameObject[Size];
    public Text go;
    bool yaaraachu_irukeengalaa = false;
    private string chapter = "chapters";//File NAME OF CHAPTERS SCENE
    private float waiter = 0;

    public void addScore(int val)
    {
        playerScore += val;
        scoreText.text = playerScore.ToString();
    }
    private void Update()
    {
            for(int i=0;i<Size;i++)
        {
            alive[i].text = Players[i].activeSelf ? (i+1).ToString() : "";
            yaaraachu_irukeengalaa|= Players[i].activeSelf; 
        }
        if (!yaaraachu_irukeengalaa)
        {
            //Debug.Log("All dead");
            go.text = "Well Played!";
            waiter += Time.deltaTime;
            if (waiter > 4f)
            {
                waiter = 0;
                Debug.Log("All dead");
                SceneManager.LoadScene(chapter);
            }
            
        }
        yaaraachu_irukeengalaa= false;
    }
    public void setChapter(string x)
    {
        chapter = x;
    }
}
