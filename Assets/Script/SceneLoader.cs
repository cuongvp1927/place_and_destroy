using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
<<<<<<< Updated upstream
{
=======
{private  int previousIndex;
    private void Start()
    {
        previousIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

>>>>>>> Stashed changes
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
