using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   using UnityEngine;
using UnityEngine.SceneManagement;

public class reutrnPreviousScene : MonoBehaviour
{




    public void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene", "Level Select Scn")); // 加载上一个场景
    }

}
