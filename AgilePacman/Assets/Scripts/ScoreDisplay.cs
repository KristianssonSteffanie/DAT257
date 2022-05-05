using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreDisplay : MonoBehaviour
{
    private GameManager gameManager;
    private int score;
    public TextMeshProUGUI scoreDisp;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score = gameManager.GetScore();

        scoreDisp.text = score.ToString();
    }
}
