using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    private static int score;

    public static int getScore()
    {
        return score;
    }

    public static void setScore(int newScore)
    {
        score = newScore;
    }
}
