using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectTele : MonoBehaviour
{
    [System.Serializable]
    public struct teleZone
    {
        public float teleTime;
        public Transform teleLoc;
    }
    
    private float timer;
    private GameObject teleObject;
    // [SerializeField] private List<Transform> teleLocate;
    // [SerializeField] private List<int> teleTime;
    // private Dictionary<int, int> teleMap = new Dictionary<int, int>();
    public List<teleZone> teleZones;
    private int curr = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 99;
        foreach (Transform child in this.transform)
        {
            if (child.tag == "Objective")
            {
                teleObject = child.gameObject;
                break;
            }
        }
    }

    private void teleport(Vector3 loc)
    {
        if (teleObject != null)
        {
            teleObject.transform.position = loc;
        }
        else
        {
            Debug.Log("Object has been destroyed or was never there");
        }
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= teleZones[curr].teleTime)
        {
            teleport(teleZones[curr].teleLoc.position);
            curr++;
            if (curr >= teleZones.Count)
            {
                curr = 0;
            }
            timer = 0;
        }
    }
}
