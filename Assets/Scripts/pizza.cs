using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza : MonoBehaviour
{
    bool alreadyhit;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(!alreadyhit){
            alreadyhit = true;
            Destroy(this.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManager>().addPizza();
            //Debug.Log("PIZZA");
        }
    }
}
