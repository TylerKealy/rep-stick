using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public Text currentScoreNumber;
    public Text highScoreNumber;
    public Text start;
    public Text instructions;
    public int highScore;

    public int enemyCount = 0;
    public int Points
    {
        
        get
        {
            return points;
        }
        set
        {
            points = value;
            //Update text and stuff here
            string newScore = "";
            for (int i = 0; i < 21; i++) 
            {
                newScore += points + "\n";

            }

            currentScoreNumber.text = newScore;

            if (points >= highScore) 
            {
                highScore = points;


            }
            string newHighScore = "";
            for (int i = 0; i < 21; i++)
            {
                newHighScore += highScore + "\n";

            }
            highScoreNumber.text = newHighScore;

        }
    }
    private int points = 0;


    private void Start()
    {
       highScore = PlayerPrefs.GetInt("HighScore", 0);
        string newHighScore = "";
        for (int i = 0; i < 21; i++)
        {
            newHighScore += highScore + "\n";

        }
        highScoreNumber.text = newHighScore;

    }

    void Update()
    {
        Debug.Log("Enemy Count is " + enemyCount);
        Debug.Log("Points is " + points);
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Destroy(start);
            Destroy(instructions);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
