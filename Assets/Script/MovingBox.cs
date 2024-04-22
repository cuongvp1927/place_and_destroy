using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingBox : MonoBehaviour{
    // [SerializeField] string boxType;
    
    public enum BoxType
    {
        wood, 
        metal,
        dinamite,
        balloon,
    }

    public BoxType boxType;

    // public void destroySelf()
    // {
    //     Destroy(gameObject);
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "moveable")
        {
            // Destroy(other.gameObject);
            MovingBox otherBox = other.gameObject.GetComponent<MovingBox>();
            Debug.Log(otherBox.boxType);
            if (this.gameObject.GetComponent<MovingBox>().boxType == BoxType.metal &&
                other.gameObject.GetComponent<MovingBox>().boxType == BoxType.wood
                )
            {
                Destroy(other.gameObject);
            }
        }
    }

}
