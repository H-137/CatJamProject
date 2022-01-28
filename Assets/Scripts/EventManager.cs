using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class _UnityEventFloat:UnityEvent<int, int, bool, bool> {}

[System.Serializable] public class _UnityEventFloat2:UnityEvent<int, int, bool, bool> {}

public class EventManager : MonoBehaviour
{
    
    [Header("I'm not seeing enough movement!")]
    public _UnityEventFloat playerMovement;

    public _UnityEventFloat2 playerAnimation;

    private int xMovement;

    private int zMovement;

    private bool jump;

    private bool crouch;

    public bool gameOver;

    public int holdingJump;



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
        xMovement = 0;
        zMovement = 0;
        jump = false;
        crouch = false;
        if(Input.GetKey("d") ){
            xMovement+=1;
        }
        if(Input.GetKey("a")){
            xMovement-=1;
        }

        if(Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)){
            zMovement +=1;
        }
        if(Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)){
            zMovement -=1;
        }
        if(Input.GetKey(KeyCode.Space)){
            jump = true;
            holdingJump++;
        } else {
            holdingJump = 0;
        }
        if(Input.GetKey(KeyCode.LeftControl)){
            crouch = true;
        }
        if(Input.GetKey("f")){
            GameObject.Find("GameManager").GetComponent<GameManager>().goPizza();
        }
        if(!gameOver){
            playerMovement.Invoke(xMovement,zMovement, jump, crouch);
            playerAnimation.Invoke(xMovement,zMovement, jump, crouch);
        } else {
            if(Input.GetKey(KeyCode.Space)){
                SceneManager.LoadScene( SceneManager.GetActiveScene().name );
            }
        }
    }
}
