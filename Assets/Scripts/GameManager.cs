using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int final, slices;

    public TMP_Text gameOverScore;

    public GameObject cat;

    public GameObject gameOverCanvas, scoreCanvas;

    public Sprite[] pizzaSprites;

    public GameObject pizzaImage;

    public bool pizzaTime;

    float time = 5;

    IEnumerator coroutine;

    public TMP_Text countDown;

    public static int highscore;


    bool ran;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        coroutine = pizzaTimer();
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        Debug.Log(highscore);
    }

    public void gameOver(){
        final = this.GetComponent<score>().STOPCOUNT();
        if(final > highscore){
            highscore = final;
            Debug.Log(highscore);
            PlayerPrefs.SetInt("highscore", highscore);
            gameOverScore.text = "GAME OVER \n SCORE: " + final + "\n NEW HIGH SCORE!";
        } else if(highscore >= final){
            gameOverScore.text = "GAME OVER \n SCORE: " + final + "\n HIGH SCORE: " + highscore;
        }
        //Utilities.setFinalScore(final);
        gameOverCanvas.GetComponent<Canvas>().enabled = true;
        scoreCanvas.GetComponent<Canvas>().enabled = false;
        this.GetComponent<EventManager>().gameOver= true;
        cat.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void reset(){
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }

    public void addPizza(){
        if(slices<4){
            slices++;
            pizzaImage.GetComponent<Image>().sprite = pizzaSprites[slices];
        }
    }

    public void subPizza(){
        if(slices>0){
            slices--;
            pizzaImage.GetComponent<Image>().sprite = pizzaSprites[slices];
        }
    }

    public int checkPizza(){
        return slices;
    }

    public void goPizza(){
        if(slices >= 4){
            slices = 0;
            pizzaImage.GetComponent<Image>().sprite = pizzaSprites[0];
            pizzaTime = true;
            countDown.enabled = true;
            StartCoroutine(coroutine);
        }
    }

    IEnumerator pizzaTimer(){
        while (true){
            countDown.text = "" + (int)time;
            yield return new WaitForSeconds(1);
            time--;
            Debug.Log("Time left: " + time);
            if(time<=0){
                countDown.enabled = false;
                StopCoroutine(coroutine);
                time = 5;
                pizzaTime = false;
                countDown.enabled = false;
            }
        }
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }

}
