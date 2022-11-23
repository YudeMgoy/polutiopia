using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static string sceneToLoad;
    public static string SceneToLoad{get => sceneToLoad;}
    //load
    public static void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //progress load
    public static void ProgressLoad(string sceneName)
    {
        sceneToLoad = sceneName;
        // Debug.Log("Loading Progress sceneName");
        SceneManager.LoadScene("LoadingProgress");
    }
    //reload level
    public static void ReloadLevel()
    {
        var currentScene = SceneManager.GetActiveScene().name;
        ProgressLoad(currentScene);
    }

    //loadnextlevel
    public static void LoadNextLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        int nextLevel = int.Parse (currentSceneName.Split("Level")[1])+1;
        string nextSceneName = "Level" + nextLevel;

        if(SceneUtility.GetBuildIndexByScenePath(nextSceneName)==-1)
        {
            Debug.LogError(nextSceneName+" does not exists");
            return;
        }
        ProgressLoad(nextSceneName);
    }
}
