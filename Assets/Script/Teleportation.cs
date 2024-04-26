using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    private GameObject teleBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool VictoryCheck()
    {
        GameObject[] goal = GameObject.FindGameObjectsWithTag("Objective");
        if (goal.Length == 0)
        {
            Debug.Log("Victory");
            return true;
        }

        return false;
    }
    // Update is called once per frame
    void Update()
    {
        VictoryCheck();
        if (teleBox)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Ray camRay = Camera.main.ScreenPointToRay(mousePos);
                var rayHit = Physics2D.GetRayIntersection(camRay);
                if (rayHit.collider)
                {
                    if (rayHit.collider.gameObject == teleBox)
                    {
                        teleBox = null;
                    }
                    return;
                };
                
                Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
                worldMousePos.z = 0f;
                teleBox.transform.position = worldMousePos;
                teleBox = null;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                Ray camRay = Camera.main.ScreenPointToRay(mousePos);
                var rayHit = Physics2D.GetRayIntersection(camRay);
                if (!rayHit.collider) return;

                if (rayHit.collider.gameObject.tag == "moveable")
                {
                    // Debug.Log(rayHit.collider.gameObject.name);
                    teleBox = rayHit.collider.gameObject;
                }
            }
        }
       
        
    }
}
