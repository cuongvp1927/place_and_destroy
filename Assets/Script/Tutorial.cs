using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [System.Serializable]
    public struct resetZone
    {
        public GameObject obj;
        public Transform teleLoc;
    }
    
    [SerializeField] private GameObject mess1;
    [SerializeField] private GameObject mess2;
    [SerializeField] private GameObject mess3;

    private GameObject teleBox;
    private int teleCount;
    private int step = 0;
    public List<resetZone> ResetZones;
    
    // Start is called before the first frame update
    void Start()
    {
        step = 0;
        mess1.SetActive(true);
        mess2.SetActive(false);
        mess3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        teleBox = gameObject.GetComponent<Teleportation>().TeleBox;
        teleCount = gameObject.GetComponent<Teleportation>().TeleCount;
        
        // after clicking on the item
        if (teleBox && step ==0)
        {
            mess1.SetActive(false);
            mess2.SetActive(true);
            mess3.SetActive(false);
            step++;
        }
        
        // after the first teleport
        if (teleCount >= 1 && step ==1 )
        { 
            foreach (resetZone zone in ResetZones)
            {
                if (zone.obj)
                {
                    zone.obj.transform.position = zone.teleLoc.position;
                }
            }

            mess1.SetActive(false);
            mess2.SetActive(false);
            mess3.SetActive(true);
            step++;
        }
    }
}
