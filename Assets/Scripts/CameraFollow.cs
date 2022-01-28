using UnityEngine;
using System.Collections;

        public class CameraFollow : MonoBehaviour {

        public GameObject player;
        private Transform target;
        public float distance = 3.0f;
        public float height = 3.0f;
        public float damping = 5.0f;
        public bool smoothRotation = true;
        public bool followBehind = true;
        public float rotationDamping = 10.0f;

        private bool flipped;

        private bool newFlip;

        public bool lockX;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            target = player.GetComponent<Rigidbody>().transform;
        }

        void FixedUpdate (){
                Vector3 wantedPosition;
                if(followBehind){
                        wantedPosition = target.TransformPoint(0, height, -distance);
                }
               else wantedPosition = target.TransformPoint(0, height, distance);
               transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
               if(wantedPosition.z < transform.position.z){
               transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z-6);    
               }
               if(lockX){
               transform.position = new Vector3(player.transform.position.x, transform.position.y, -12);    
               }

               if (smoothRotation) {
                       Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
                       transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
               }
               else transform.LookAt (target, target.up);
         }
}