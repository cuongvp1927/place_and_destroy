using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
<<<<<<< Updated upstream
{
<<<<<<< HEAD
=======
{private  int previousIndex;
=======
    [SerializeField] private  int previousIndex;
>>>>>>> level2
    private void Start()
    {
        previousIndex = SceneManager.GetActiveScene().buildIndex - 1;
    }

<<<<<<< HEAD
>>>>>>> Stashed changes
=======
>>>>>>> level2
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    public void reloadScene()
    {
        SceneManager.LoadScene(previousIndex);
    }
}
