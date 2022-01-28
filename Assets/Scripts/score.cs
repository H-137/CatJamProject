using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class score : MonoBehaviour
{
    public TMP_Text scoreText;

    private float scoreCount;

    private bool yesCount;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(!yesCount){
            scoreCount += Time.deltaTime;
            scoreText.text = "" + (int)scoreCount;
        }
    }

    public int STOPCOUNT(){
        yesCount = true;
        return (int)scoreCount;
    }
}
