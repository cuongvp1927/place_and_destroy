using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointForm : MonoBehaviour
{
    // Start is called before the first frame update store way point 
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private GameObject[] waypoints;

    void Update()
    {
        
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //iterm move towards to way points
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

   
}
