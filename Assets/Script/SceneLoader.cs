using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string previousSceneName;

    void Start()
    {

    }

    // 在场景切换时调用，保存当前场景的名称作为上一个场景的名称
    void OnDisable()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
