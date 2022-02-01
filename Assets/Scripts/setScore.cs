using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setScore : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "SCORE: " + Utilities.highScore;
    }

}
