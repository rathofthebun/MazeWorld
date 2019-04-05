using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [Header("Preset GameObjects")]
    [SerializeField] GameObject[] startingPoints; // predefined starting point objects, with given position for each
    [SerializeField] GameObject arrowAvatar; // any prefab object that can represent the looking of an arrow
    private ArrowCollisionCheck arrowCollider; // a sub-script in charge of actual trigger check
    public bool initialized = false; // instruction bool to be controlled by the Level Manager
    public bool completed = false; // feedback bool to be sent back to notify the LevelManager
    [SerializeField] bool debug = false;
    void Start()
    {
        arrowCollider = arrowAvatar.GetComponent<ArrowCollisionCheck>();
        arrowAvatar.SetActive(false); //arrowAvatar not visible at initialization
    }

    // Update is called once per frame
    void Update()
    {
        if (initialized){
            completed = arrowCollider.playerArrived; // check the status of arrow
            if(completed){ //if arrived, mission complete
                arrowCollider.playerArrived = false; // reset arrowCollider
                arrowAvatar.SetActive(false); // turn off avatar to be not active in the scene
                initialized = false; // finish the mission, done with checking every loop
            }
        }
    }

    //level manager call "activateArrow(int)" function by giving an index value
    //to reference one of the start point objects that arrow avatar can teleport to
    //and set initialized value to be true
    public void activateArrow(int arrowPosIndex){
        if (startingPoints[arrowPosIndex] != null){
            arrowAvatar.transform.position = startingPoints[arrowPosIndex].transform.position; 
            arrowAvatar.SetActive(true);
            initialized = true;
        }
    }
    public void resetArrow(){
        initialized = false;
        arrowCollider.playerArrived = false;
        arrowAvatar.SetActive(false);
    }
}
