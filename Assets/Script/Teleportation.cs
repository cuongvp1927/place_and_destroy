using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
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
        portalDestroy,
    }

    private State currState;
    
    [SerializeField] int teleMax = 1; // maximum number of teleportation 
    private int teleCount = 0; // the current use of teleportation ( if we exceed the number of teleportation counts the player fails) 
    public bool isWin = false; // if the playercompletes the level 
    public bool isLose = false;// if the player fails the level
    private float timer = 0;// the current time count for the level
    private float loseTimer = -1;// the time the player finish the final teleport
    private float teleDone = -1;// the time the player create the final portal, completing a teleport
    [SerializeField] private float loseInterval = 2; // the interval count to player losing the level
    [SerializeField] private float portalDestroyInterval = 0.5f; // the interval count to player losing the level

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
        VictoryCheck(); // check for victory every frame, this function is called every frame
        
        // if already teleport, destroy both portal and reset the state to 1
        if (currState == State.portalDestroy)
        {
            if ((timer - teleDone) > portalDestroyInterval)
            {
                Destroy(portalIn);
                Destroy(portalOut);
                currState = State.spawnIn;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;// take the position of the mouse and storing t 
                Ray camRay = Camera.main.ScreenPointToRay(mousePos);// the position is translated to a place on the screen 
                var rayHit = Physics2D.GetRayIntersection(camRay); // using the position to see any object with the collide
                // if (rayHit.collider)
                // {
                //     return;
                // }
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos); // transform mousePos into usable variable
                worldMousePos.z = 0f;
                // if haven't spawn the first portal, create the first portal
                if (currState == State.spawnIn)
                {
                    portalIn =  Instantiate<GameObject>(portalInInstant, worldMousePos, Quaternion.identity);
                    currState = State.spawnOut;
                }
                else
                {
                    // if haven't spawn the second portal, create the first portal, the make the teleport
                    if (currState == State.spawnOut)
                    {
                        portalOut =  Instantiate<GameObject>(portalOutInstant, worldMousePos, Quaternion.identity);
                        
                        portalIn.GetComponent<Portal>().portalOut = portalOut;
                        portalOut.GetComponent<Portal>().portalOut = portalIn;
                        
                        portalIn.GetComponent<Portal>().willTele = true;
                        portalOut.GetComponent<Portal>().willTele = true;
                        
                        currState = State.portalDestroy;
                        teleDone = timer;
                        teleUsed();
                        if (teleCount >= teleMax)
                        {
                            loseTimer = timer;
                        }
                    }
                }
            }
        }
        
        if (isWin)
        {
            Debug.Log("You win");
            // string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // SceneManager.LoadScene("VictoryScene");
        }
        if (isLose)
        {
            Debug.Log("You lose");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
            // SceneManager.LoadScene("LoseScene");
        }
        
    }
}
