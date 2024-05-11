using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterSingleton : MonoBehaviour
{
    // Create a singleton
    private static GameMasterSingleton _instance;

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
            DontDestroyOnLoad(gameObject);
        }
    }
    // Moving through scene
    private string _lastScene;
    private string _currScene;

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
    public void ReloadScene()
    {
        SceneManager.LoadScene(_currScene);
    }
    
    public void LoadLastScene()
    {
        string token = _lastScene;
        _lastScene = _currScene;
        _currScene = token;
        SceneManager.LoadScene(_currScene);
        
    }
    
    // Dealing with sound
    public List<Sound> MusicList, SFXList;
    public AudioSource MusicSource, SFXSource;
    public void PlayMusic(string name)
    {
        Sound sound = MusicList.Find(x => x.name == name);
        if (sound == null)
        {
            Debug.Log("No soundtrack of that name");
        }
        else
        {
            MusicSource.clip = sound.clip;
            MusicSource.Play();
            MusicSource.loop = true;
        }
    }
    public void MuteMusic()
    {
        MusicSource.mute = true;
    }
    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }
    
    public void PlaySFX(string name)
    {
        Sound sound = SFXList.Find(x => x.name == name);
        if (sound == null)
        {
            Debug.Log("No soundtrack of that name");
        }
        else
        {
            // SFXSource.clip = sound.clip;
            SFXSource.PlayOneShot(sound.clip);
        }
    }
    public void MuteSFX()
    {
        SFXSource.mute = true;
    }
    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
    
    // when start game, play music
    [SerializeField] private string themeSong;

    void Start()
    {
        PlayMusic(themeSong);
    }
}
