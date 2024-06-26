using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    // private GameObject teleBox=null; // the box that will be teleported 

    enum State
    {
        spawnIn,
        spawnOut,
        allowingTele,
        portalDestroy,
    }

    private State currState;
    
    [SerializeField] int teleMax = 1; // maximum number of teleportation 
    private int teleCount = 0; // the current use of teleportation ( if we exceed the number of teleportation counts the player fails) 
    [HideInInspector] public bool isWin = false; // if the playercompletes the level 
    [HideInInspector] public bool isLose = false;// if the player fails the level
    private float timer = 0;// the current time count for the level
    private float loseTimer = -1;// the time the player finish the final teleport
    private float teleDone = -1;// the time the player create the final portal, completing a teleport
    [SerializeField] private float loseInterval = 2; // the interval count to player losing the level
    [SerializeField] private float portalDestroyInterval = 0.5f; // the interval count to player losing the level
    
    // UI
    [SerializeField] private GameObject timerText; // Timer text
    [SerializeField] private GameObject teleportText; // Timer text
    [SerializeField] private GameObject maxTeleText; // Timer text

    [SerializeField] private GameObject portalInInstant;
    [SerializeField] private GameObject portalOutInstant;
    
    private GameObject portalIn =null;
    private GameObject portalOut = null;
    
    public GameObject Portal1 => portalIn;
    public GameObject Portal2 => portalOut;
    
    // public GameObject TeleBox => teleBox;
    public int TeleCount => teleCount;

    void teleUsed() // function for increasing the teleportation count 
    {
        teleCount += 1;
    }
    void VictoryCheck() // fuction to check the winning condition
    {
        GameObject[] goal = GameObject.FindGameObjectsWithTag("Objective"); // finding the objects everywhere in the scene and putting the objects in an array
        if (goal.Length == 0) // counter for length of the array, if the length is 0 ,
        {
            isWin = true; // then the player wins as isWin =true 
        }
        else
        {
            if (teleMax <= teleCount && loseTimer+loseInterval<=timer && loseTimer>0) // if the number of used teleport greater than or equals  the maximum allowed teleportation 
            {
                isLose = true; //the player losses
            }
        }
    }

    private void Start()
    {
        timer = 0;
        currState = State.spawnIn;

    }

    // Update is called once per frame
    void Update()// for the rest of the frames 
    {
        timer += Time.deltaTime;// updating the the counter for the time passed
        int second = Mathf.FloorToInt(timer/60);
        int minute = Mathf.FloorToInt(timer%60);
        timerText.GetComponent<TextMeshProUGUI>().text = string.Format("{0:00} : {1:00}", second, minute);
        
        // show current teleport used
        teleportText.GetComponent<TextMeshProUGUI>().text = teleCount.ToString();
        
        // show maximum teleport used
        maxTeleText.GetComponent<TextMeshProUGUI>().text = teleMax.ToString();
        
        
        VictoryCheck(); // check for victory every frame, this function is called every frame
        
        // if already teleport, destroy both portal and reset the state to 1
        switch ( currState)
        {
            // if haven't spawn the first portal, create the first portal
            case State.spawnIn:
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePos = Input.mousePosition; // take the position of the mouse and storing t 
                    Ray camRay =
                        Camera.main.ScreenPointToRay(mousePos); // the position is translated to a place on the screen 
                    var rayHit =
                        Physics2D.GetRayIntersection(camRay); // using the position to see any object with the collide

                    Vector3 worldMousePos =
                        Camera.main.ScreenToWorldPoint(mousePos); // transform mousePos into usable variable
                    worldMousePos.z = 0f;
                    
                    portalIn =  Instantiate<GameObject>(portalInInstant, worldMousePos, Quaternion.identity);
                    currState = State.spawnOut;
                }

                break;
            }
            // if haven't spawn the second portal, create the first portal, the make the teleport
            case State.spawnOut:
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePos = Input.mousePosition; // take the position of the mouse and storing t 
                    Ray camRay =
                        Camera.main.ScreenPointToRay(mousePos); // the position is translated to a place on the screen 
                    var rayHit =
                        Physics2D.GetRayIntersection(camRay); // using the position to see any object with the collide

                    Vector3 worldMousePos =
                        Camera.main.ScreenToWorldPoint(mousePos); // transform mousePos into usable variable
                    worldMousePos.z = 0f;
                    
                    portalOut =  Instantiate<GameObject>(portalOutInstant, worldMousePos, Quaternion.identity);
                    currState = State.allowingTele;
                }
                break;
            }
            case State.allowingTele:
            {
                portalIn.GetComponent<Portal>().portalOut = portalOut;
                portalOut.GetComponent<Portal>().portalOut = portalIn;
            
                portalIn.GetComponent<Portal>().willTele = true;
                portalOut.GetComponent<Portal>().willTele = true;
            
                teleDone = timer;
                teleUsed();
                GameMasterSingleton.Instance.PlaySFX("ObjectTeleport");
                currState = State.portalDestroy;
                if (teleCount >= teleMax)
                {
                    loseTimer = timer;
                }
                break;
            }
            case State.portalDestroy:
            {
                if ((timer - teleDone) > portalDestroyInterval)
                {
                    Destroy(portalIn);
                    Destroy(portalOut);
                    currState = State.spawnIn;
                }
                break;
            }
            default:
            {
                Debug.Log("Unknown state");
                break;
            }
        }

        if (Input.GetButtonDown("Reset level"))
        {
            Debug.Log("You just press reset");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameMasterSingleton.Instance.ReloadScene();
        }
        
        if (isWin)
        {
            Debug.Log("You win");
            GameMasterSingleton.Instance.LoadVictory();
            GameMasterSingleton.Instance.PlaySFX("Win");
            // SceneManager.LoadScene("VictoryScene");
        }
        if (isLose)
        {
            Debug.Log("You lose");
            // string currentSceneName = SceneManager.GetActiveScene().name;
            // SceneManager.LoadScene(currentSceneName);
            GameMasterSingleton.Instance.LoadNewScene("LoseScene");
            GameMasterSingleton.Instance.PlaySFX("Lose");
            // SceneManager.LoadScene("LoseScene");
        }
        
    }
}
