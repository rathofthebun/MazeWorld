﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] KeyCode newGameKey = KeyCode.N;
    public int levelCount;
    int loadedLevelBuildIndex;
    SimpleFade fadeManager;
    [SerializeField] Scene[] mazePool;
    int currentLevel;
    
    void Start()
    {
        fadeManager = SimpleFade.Instance;

        //initial check if there is anything already accidentally loaded
        if (Application.isEditor) {
			for (int i = 0; i < SceneManager.sceneCount; i++) {
				Scene loadedScene = SceneManager.GetSceneAt(i);
                //make sure level contains word Maze
				if (loadedScene.name.Contains("Maze")) {
					SceneManager.SetActiveScene(loadedScene);
					loadedLevelBuildIndex = loadedScene.buildIndex;
					return;
				}
			}
        }
    }

    // Update is called once per frame
    void Update()
    {
        //refresh and reload the current scene, in case any bug happens.
        if (Input.GetKeyDown(newGameKey)){ 
			StartCoroutine(LoadLevel(loadedLevelBuildIndex));
		} 

    }

    //"selectLevel(int)" function is to be called by MazeManager after checking the arrowmanager
    public void SelectLevel(int levelIndex){
        StartCoroutine(LoadLevel(levelIndex));
        //Debug.Log(levelName);
    }

    //levelCheck() is mostly an unload level function
    //it is to be called before the arrowManager so that the scene goes back to empty, and arrow can appear  
    public void LevelCheck(){
        StartCoroutine(UnloadLevel());
        //Debug.Log(levelName);
    }

    IEnumerator LoadLevel (int levelBuildIndex) {
		enabled = false; // <-- this is the Unity Behavior enable bool
        fadeManager.fadingNeeded = true;

        //unload existing scene
		if (loadedLevelBuildIndex > 0) {
			yield return SceneManager.UnloadSceneAsync(loadedLevelBuildIndex);
		}

		//async loading for multiple frames, can also show a loading screen at this point
		yield return SceneManager.LoadSceneAsync(
			levelBuildIndex, LoadSceneMode.Additive
		);
		SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelBuildIndex));
		loadedLevelBuildIndex = levelBuildIndex;
		enabled = true;
        fadeManager.fadingNeeded = false;
	}
    IEnumerator UnloadLevel(){
        enabled = false; // <-- this is the Unity Behavior enable bool
        fadeManager.fadingNeeded = true;
        if (loadedLevelBuildIndex > 0) {
			yield return SceneManager.UnloadSceneAsync(loadedLevelBuildIndex);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
		loadedLevelBuildIndex = 0;
		enabled = true;
        fadeManager.fadingNeeded = false;
    }

}
