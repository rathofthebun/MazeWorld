using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollisionCheck : MonoBehaviour
{
    public bool playerArrived = false;
    [SerializeField] bool debug = false;
    void Update(){
        if (debug){
            if (playerArrived){
                Debug.Log("player Arrived");
            }
        }
    }
    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            playerArrived = true;
            Debug.Log("arrow collision detected");
        }
    }
}
