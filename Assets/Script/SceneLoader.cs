using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour

{private  int previousIndex;



    private void Start()
    {
        previousIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }


    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(previousIndex);
    }
}
