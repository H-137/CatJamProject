using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScript : MonoBehaviour
{
    public void loadGame(){
        SceneManager.LoadScene("GamePlay");
    }

    public void loadStart(){
        SceneManager.LoadScene("Start");
    }

    public void loadInstructions(){
        SceneManager.LoadScene("Instructions");
    }

    public void loadLeaderboard(){
        SceneManager.LoadScene("Leaderboard");
    }

    public void loadScoreSubmit(){
        if(Utilities.highScore > GameObject.Find("GameManager").GetComponent<SubmitScoreScript>().scoreArr[4]){
            SceneManager.LoadScene("ScoreSubmit");
        } else {
            StartCoroutine(warningMessage());
        }
    }

    public IEnumerator warningMessage(){
        GameObject.Find("warning").GetComponent<TMP_Text>().enabled = true;
        yield return new WaitForSeconds(2);
        GameObject.Find("warning").GetComponent<TMP_Text>().enabled = false;
    }

    public void loadCredits(){
        SceneManager.LoadScene("Credits");
    }
}
