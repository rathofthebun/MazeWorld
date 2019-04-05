using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeManager : MonoBehaviour
{
    [SerializeField] LevelLauncher levelManager;
    [SerializeField] ArrowManager arrowManager;
    //[SerializeField] TimeManager timeManager;
    //[SerializeField] LogManager logManager;
    int currentLevel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

        //keyboard number based maze selection.
        for (int i = 1; i <= levelManager.levelCount; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha0 + i)) { // maze selection by keyboard number shortcut
                levelManager.LevelCheck(); //check level and unload existing level
                currentLevel = i; // 
                Debug.Log(currentLevel - 1);
                arrowManager.resetArrow();
                arrowManager.activateArrow(currentLevel - 1);
				return;
			}
		}

        //TO DO: a random generator select an int within a range
        // avoid selecting the same number that has been chosen.
        if (Input.GetKeyDown(KeyCode.R)){ //press R to random generate a number, or whatever condition we define later
            currentLevel = Random.Range(0, levelManager.levelCount); // <- random number should write value into "currentLevel"
            Debug.Log(currentLevel);
            arrowManager.resetArrow();
            arrowManager.activateArrow(currentLevel - 1);
        }

        //check on arrowManager
        if (arrowManager.completed == true){
            levelManager.SelectLevel(currentLevel);
            Debug.Log("loaded current scene");
            arrowManager.completed = false; // reset arrowManager
            //TO DO: give instruction to log manager to let it start to work
        }

        //TO DO: check on timeManager
        //if timer returns "time over", log and reselect maze?

        //TO DO: check on log manager
        //
    }
    void RandomMazeChoice(){
        // return 
    }
}
