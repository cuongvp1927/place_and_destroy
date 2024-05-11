using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // [SerializeField] private  int previousIndex;
    // private void Start()
    // {
    //     previousIndex = SceneManager.GetActiveScene().buildIndex - 1;
    // }

    public void SceneLoad(string sceneName)
    {
        // SceneManager.LoadScene(sceneName);
        GameMasterSingleton.Instance.LoadNewScene(sceneName);
    }

    // public void nextScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }
    
    public void reloadScene()
    {
        GameMasterSingleton.Instance.LoadLastScene();
    }
}
