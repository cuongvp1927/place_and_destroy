using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject portalOut;

    public float cd;
    [SerializeField] private float cdMax = 1;
    [HideInInspector] public bool willTele;
    private GameObject teleBox = null;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        cd = 99;
        willTele = false;
        GameMasterSingleton.Instance.PlaySFX("PortalCreate");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("portal") && !other.gameObject.CompareTag("moveable") )
        {
            GameMasterSingleton.Instance.isCheated = true;
        }

        if (other.gameObject.CompareTag("moveable") || other.gameObject.CompareTag("Objective"))
        {
            teleBox = other.gameObject;
        }
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
