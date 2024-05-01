using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Box : MonoBehaviour{
    // [SerializeField] string boxType;
    
    public enum BoxType
    {
        wood, 
        metal,
        dinamite,
        balloon,
    }

    public BoxType boxType;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
        if (this.gameObject.tag == "moveable")
        {
            if (other.gameObject.tag == "Objective" || other.gameObject.tag=="bonus")
            Destroy(other.gameObject);
        }
            
    }

}
