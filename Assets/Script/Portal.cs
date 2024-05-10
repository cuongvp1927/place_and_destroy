using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [HideInInspector] public GameObject portalOut = null;

    public float cd;
    [SerializeField] private float cdMax = 1;
    [HideInInspector] public bool willTele;
    private GameObject teleBox = null;
    
    // Start is called before the first frame update
    void Start()
    {
        cd = 99;
        willTele = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        teleBox = other.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        cd += Time.deltaTime;

        if (willTele && portalOut.gameObject.GetComponent<Portal>().willTele && teleBox)
        {
            teleBox.transform.position = portalOut.transform.position;
            willTele = false;
            portalOut.GetComponent<Portal>().willTele = false;
            teleBox = null;

        }

    }
}
