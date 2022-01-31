using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
}
