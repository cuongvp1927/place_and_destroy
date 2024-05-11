using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterSingleton : MonoBehaviour
{
    private static GameMasterSingleton _instance;

    private string _lastScene;
    private string _currScene;
    
    public static GameMasterSingleton Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void PlayMusic()
    {
        
    }

    public string GetLastScene()
    {
        return _lastScene;
    }

    public void LoadNewScene(string sceneName)
    {
        _lastScene = _currScene;
        _currScene = sceneName;
        SceneManager.LoadScene(_currScene);
    }

    // public void LoadNextScene()
    // {
    //     string token = _currScene;
    //     _lastScene = _currScene;
    //     _currScene = sceneName;
    //     SceneManager.LoadScene(_currScene);
    // }
    
    public void LoadLastScene()
    {
        string token = _lastScene;
        _lastScene = _currScene;
        _currScene = token;
        SceneManager.LoadScene(_currScene);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
