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

    // Update is called once per frame
    void Update()
    {
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
