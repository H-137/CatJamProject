using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static int finalScore;
    public static int highScore;
    public static bool onFloor = false;

    public static bool setFinalScore(int score){
        finalScore = score;
        if(finalScore > highScore){
            highScore = finalScore;
            return true;
        }
        return false;
    }
}
