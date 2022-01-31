using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    //Rigidbody of the player
    private Rigidbody _cube;

    //private bool onGround, zMax, xMax, isRotated;

    private float xAdd, zAdd, speed, newXVel, distanceInAir;
    public bool isRunner;
    MeshFilter myMesh;
    private float timer;
    private GameObject gameMan;
    private bool sameFrame;
    public GameObject road;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        speed += Time.deltaTime / 4;
        //Debug.Log(speed);
    }


    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        _cube = this.GetComponent<Rigidbody>();
        gameMan = GameObject.Find("GameManager");
    }

    public void movement(int x, int z, bool jump, bool crouch){
        if(isRunner){
            if(_cube.transform.position.z > -6 && _cube.transform.position.z < 6 ){
                _cube.velocity = new Vector3(speed, _cube.velocity.y, z * 10);
            } else {
                if(_cube.transform.position.z < 0 && z>0){
                    _cube.velocity = new Vector3(speed, _cube.velocity.y, z * 5);
                } else if(_cube.transform.position.z > 0 && z<0){ 
                    _cube.velocity = new Vector3(speed, _cube.velocity.y, z * 5);
                }else _cube.velocity = new Vector3(speed, _cube.velocity.y, 0);
            }
        } else if(Mathf.Abs(x) == Mathf.Abs(z) && x != 0) {
            _cube.velocity = new Vector3(x * Mathf.Sqrt(25/2), _cube.velocity.y, z * Mathf.Sqrt(25/2));
        }else {
            _cube.velocity = new Vector3(x * speed, _cube.velocity.y, z * 5);
        }
        if(jump){
            
            jumping();
        }
        if(crouch){
        
        } else {
            //speed = 5;
            distanceInAir = 1;
        }
        myMesh = _cube.GetComponent<MeshFilter>();

    }

    private int jumpingRay(){
        int countArr = 0;
         RaycastHit hitInfo;
        //Array of rays, in order: center, right, left, foreward, backward 
        Ray[] array = new Ray[]{new Ray(_cube.position, Vector3.down), new Ray(_cube.position + new Vector3(0.49f,0,0), Vector3.down), new Ray(_cube.position + new Vector3(-0.49f,0,0), Vector3.down),new Ray(_cube.position + new Vector3(0,0,0.49f), Vector3.down),new Ray(_cube.position + new Vector3(0,0,-0.49f), Vector3.down)};
        for(int i = 0; i<5; i++){
            Debug.DrawRay(array[i].origin,array[i].direction * 2);
            Physics.Raycast(array[i], out hitInfo, distanceInAir * 2);
            if(hitInfo.collider != null) {
                if(hitInfo.collider.tag == "Floor"){
                    countArr ++;
                }
            }
        }
        return countArr;
    }

    private void jumping(){
        int numPizzas = gameMan.GetComponent<GameManager>().checkPizza();
    
        int holdingSpace = GameObject.Find("GameManager").GetComponent<EventManager>().holdingJump;

        if(Utilities.onFloor){
            _cube.velocity = new Vector3(_cube.velocity.x,6,_cube.velocity.z);
            sameFrame = true;
        } else if(numPizzas != 0 && holdingSpace <= 1 && sameFrame == false){
            gameMan.GetComponent<GameManager>().subPizza();
            if(_cube.velocity.y > 0){
                _cube.velocity = new Vector3(_cube.velocity.x,_cube.velocity.y + 6, _cube.velocity.z);
            } else {
                _cube.velocity = new Vector3(_cube.velocity.x,6,_cube.velocity.z);
            }
        }
        sameFrame = false;      
    }
}
