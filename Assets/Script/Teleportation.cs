using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleportation : MonoBehaviour
{
    private GameObject teleBox; // the box that will be teleported 
    
    [SerializeField] int teleMax = 1; // maximum number of teleportation 
    private int teleCount = 0; // the current use of teleportation ( if we exceed the number of teleportation counts the player fails) 
    private bool isWin = false; // if the playercompletes the level 
    private bool isLose = false;// if the player fails the level
    private float timer = 0;// the current time count for the level
    private float loseTimer = -1;// the time the player finish the final teleport
    [SerializeField] private int loseInterval = 3; // the interval count to player losing the level

    public GameObject TeleBox => teleBox;

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
            if (teleMax <= teleCount && loseTimer+2<=timer && loseTimer>0) // if the number of used teleport greater than or equals  the maximum allowed teleportation 
            {
                isLose = true; //the player losses
            }
        }
    }

    private void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()// for the rest of the frames 
    {
        timer += Time.deltaTime;// updating the the counter for the time passed
        VictoryCheck(); // check for victory every frame, this function is called every frame
        if (teleBox)// if this variable is not null
        {
            if (Input.GetMouseButtonDown(0))  // on left-click 
            { 
                Vector3 mousePos = Input.mousePosition;// take the position of the mouse and storing t 
                Ray camRay = Camera.main.ScreenPointToRay(mousePos);// the position is translated to a place on the screen 
                var rayHit = Physics2D.GetRayIntersection(camRay); // using the position to see any object with the collider
                if (rayHit.collider)
                {
                    if (rayHit.collider.gameObject == teleBox)  // allowing me to deselect the box
                    {
                        teleBox = null;
                    }
                    return;
                };
                
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos); // transform mousePos into usable variable
                worldMousePos.z = 0f;
                teleBox.transform.position = worldMousePos; // actual teleporting
                teleBox = null;
                teleUsed(); //  increase the counter using the teleportation counter method
                if (teleCount <= teleMax)
                {
                    loseTimer = timer;
                }
            }
        }
        else // if teleBox is null, meaning you have not select any box to teleport
        {
            if (Input.GetMouseButtonDown(0) && (teleMax > teleCount))
            {
                Vector3 mousePos = Input.mousePosition;
                Ray camRay = Camera.main.ScreenPointToRay(mousePos);
                var rayHit = Physics2D.GetRayIntersection(camRay);
                if (!rayHit.collider)
                {
                    return;
                }

                if (rayHit.collider.gameObject.tag == "moveable") //  checking the clicking box has tag "movable"
                {
                    // Debug.Log(rayHit.collider.gameObject.name);
                    teleBox = rayHit.collider.gameObject;
                }
            }
        }

        if (isWin)
        {
            Debug.Log("You win");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        if (isLose)
        {
            Debug.Log("You lose");
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        
    }
}
