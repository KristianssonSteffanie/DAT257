using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    private int score;

    private int highScore;
    private string key = "HighScore";

    public TextMeshProUGUI scoreDisp;
    public TextMeshProUGUI highScoreDisp;


    // Start is called before the first frame update
    void Start()
    {
         score = 0;

        highScore = PlayerPrefs.GetInt(key, 0);

    }

    // Update is called once per frame
    void Update()
    {
        score = ScoreKeeper.getScore();

        scoreDisp.text = "SCORE: " + score.ToString();

        highScoreDisp.text = "HIGH SCORE: " + highScore.ToString();
    }

    void OnDisable()
    {

        //If our scoree is greter than highscore, set new higscore and save.
        if (score > highScore)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }
}
