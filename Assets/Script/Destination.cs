using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    [SerializeField] int requiredBox = 1;
    private int currentCount = 0;

    void countDown()
    {
        currentCount += 1;
    }

    bool satisfied()
    {
        return requiredBox == currentCount;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "moveable")
        {
            countDown();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (satisfied())
        {
            Debug.Log("Congratulation");
        }
    }
}
