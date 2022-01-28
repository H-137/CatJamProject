using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGen : MonoBehaviour
{   
    public GameObject player, city;

    public GameObject temp;
    public GameObject[] obst;

    public int maxZ, minZ, maxY;

    private int playerX, blocksPlaced, pblocksPlaced;

    private int cityCounter;

    public GameObject pizzaSlice;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        GameObject newObstacle = Instantiate(choseObstacle(),new Vector3(15, 0, 0), Quaternion.identity);
        GameObject cityRepeat = Instantiate(city,new Vector3(175, -7f, -3.1f), city.transform.rotation);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(player.transform.position.x - cityCounter >= 175){
            GameObject cityRepeat = Instantiate(city,new Vector3(blocksPlaced + 175, -7f, -3.1f), city.transform.rotation);
            cityCounter = (int)player.transform.position.x;
        }
        if(player.transform.position.x > blocksPlaced) {
            GameObject newObstacle = Instantiate(choseObstacle(),new Vector3(blocksPlaced + 30, 0, 0), choseRotation());
            blocksPlaced +=15;
            if(Random.Range(0,3) == 1){
                GameObject newPizza = Instantiate(pizzaSlice, new Vector3(blocksPlaced + 30 + Random.Range(-2,3), Random.Range(0,2), Random.Range(-2,3)), Quaternion.identity);
            }
        }
    }

    private GameObject choseObstacle(){
        int obj = Random.Range(0,4);
        return obst[obj];
    }

    private Quaternion choseRotation(){
        float obj = Random.Range(0,2);
        temp.transform.eulerAngles = new Vector3(
            temp.transform.eulerAngles.x,
            temp.transform.eulerAngles.y + 180 * obj,
            temp.transform.eulerAngles.z
        );
        return temp.transform.rotation;
    }
}
