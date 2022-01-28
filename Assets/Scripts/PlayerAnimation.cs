using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    // public GameObject player;
    // public GameObject cam;
    private Animator anim;
    private SpriteRenderer rend;

    public bool isRunner;
    // public bool lookAtCamera;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>

    public void Animate(int x, int z, bool jump, bool crouch){   
        anim = this.GetComponent<Animator>();
        if(x>0 && !isRunner){
            if(!(anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))){
                anim.Play("walk");
            }
            if(rend.flipX == false) {
                rend.flipX = true;
            }
        } else if(x<0) {
            if(!(anim.GetCurrentAnimatorStateInfo(0).IsName("walk"))){
                anim.Play("walk");
            }
            if(!isRunner){
                if(rend.flipX == true) {
                rend.flipX = false;
            }
            }
        }





        if(jump == true){
            
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        anim = this.GetComponent<Animator>();
        rend = this.GetComponent<SpriteRenderer>();
        //anim.Play("Look");
        if(isRunner){
            anim.Play("walk");
            rend.flipX = true;
        }
        // if(lookAtCamera){
        //     //player.transform.LookAt (cam.transform);
        // }
    }
}
