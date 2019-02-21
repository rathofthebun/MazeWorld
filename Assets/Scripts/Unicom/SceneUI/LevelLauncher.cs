using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLauncher : MonoBehaviour
{
    [SerializeField] KeyCode newGameKey = KeyCode.N;
    public int levelCount;
    int loadedLevelBuildIndex;
    SimpleFade simpleFade;
    
    void Start()
    {
        simpleFade = SimpleFade.Instance;

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
        //
    }

    // Update is called once per frame
    void Update()
    {
        //keyboard short cut, use 0, 1, 2, ... 9 to quickly load levels
        if (Input.GetKeyDown(newGameKey)){
			BeginNewRecording();
			StartCoroutine(LoadLevel(loadedLevelBuildIndex));
		} else {
			for (int i = 1; i <= levelCount; i++) {
				if (Input.GetKeyDown(KeyCode.Alpha0 + i)) {
					StartCoroutine(LoadLevel(i));
					return;
				}
			}
		}
    }
    public void SelectLevel(int levelIndex){
        StartCoroutine(LoadLevel(levelIndex));
        CameraSwitch();
        BeginNewRecording();
        //Debug.Log(levelName);
    }
    void CameraSwitch(){

    }
    void BeginNewRecording(){

    }
    IEnumerator LoadLevel (int levelBuildIndex) {
		enabled = false; // <-- this is the Unity Behavior enable bool
        simpleFade.fadingNeeded = true;

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
        simpleFade.fadingNeeded = false;
	}
}
