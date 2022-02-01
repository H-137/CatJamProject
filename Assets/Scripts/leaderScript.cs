using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderScript : MonoBehaviour
{
    public TMP_Text Scores, Names;

    private string[] nameArr;
    private int[] scoreArr;
    private GameObject gm;

    void setLeaderboard(){
        gm.GetComponent<SubmitScoreScript>().recieveLeaderboard();
        scoreArr = gm.GetComponent<SubmitScoreScript>().scoreArr;
        nameArr = gm.GetComponent<SubmitScoreScript>().nameArr;
        Debug.Log(scoreArr[0]);
        for(int i = 0; i < scoreArr.Length; i++){
            Debug.Log(nameArr[i] + " " + scoreArr[i]);
            Scores.text += scoreArr[i] + "\n";
            Names.text += nameArr[i] + "\n";
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gm = GameObject.Find("GameManager");
        // setLeaderboard();
        // gm.GetComponent<SubmitScoreScript>().recieveLeaderboard();
    }
    

}
