using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [HideInInspector] public GameObject portalOut = null;

    // private float cd;
    // [SerializeField] private float cdMax = 1;
    [HideInInspector] public bool willTele;
    private GameObject teleBox = null;
    
    // Start is called before the first frame update
    void Start()
    {
        // cd = cdMax;
        willTele = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        teleBox = other.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (portalOut.gameObject.GetComponent<Portal>().willTele)
        {
            teleBox.transform.position = portalOut.transform.position;
            willTele = false;
            portalOut.GetComponent<Portal>().willTele = false;
        }
        else
        {
            Debug.Log("no other portal");
        }
        // if (cd>=0 && )

    }
}
