using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public GameObject gameMan;

    private bool alreadyHit;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        gameMan = GameObject.Find("GameManager");
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "obst" && gameMan.GetComponent<GameManager>().pizzaTime) {
            Destroy(gameObject);
        } else {
            if(!alreadyHit){
                gameMan.GetComponent<GameManager>().gameOver();
                alreadyHit = true;
            }
        }
    }
}
