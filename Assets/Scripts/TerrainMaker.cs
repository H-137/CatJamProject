using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMaker : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject player;
    private Quaternion floorRotation;
    private int playerX;
    private int loadedRoad;

    private int roadCount = 1;

    private void addRoads(){
        playerX = (int)player.transform.position.x;
        playerX = playerX - (playerX%10) + 10;
        if(playerX > loadedRoad){
            GameObject.Instantiate(spawnObject,new Vector3(roadCount * 15, 0, 0), floorRotation);
            loadedRoad = playerX;
            roadCount++;
        }
    }
    void Start()
    {
        floorRotation = spawnObject.transform.rotation;
        //addRoads();
    }
    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        addRoads();
    }
}
