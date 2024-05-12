using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneLoad(string sceneName)
    {
        // SceneManager.LoadScene(sceneName);
        GameMasterSingleton.Instance.LoadNewScene(sceneName);
    }

    public void ReloadScene()
    {
        GameMasterSingleton.Instance.ReloadScene();
    }
    public void LoadLastScene()
    {
        GameMasterSingleton.Instance.LoadLastScene();
    }
}
