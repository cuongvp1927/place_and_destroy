using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class objectTele : MonoBehaviour
{
    [System.Serializable]
    public struct teleZone
    {
        public float teleTime;
        public Transform Portal1Loc;
        public Transform Portal2Loc;
        private GameObject portal1;
        private GameObject portal2;
    }
    private enum State
    {
        createPortal1,
        createPortal2,
        linkPortals,
        destroyPortals,
    }

    private State currState;
    public List<teleZone> teleZones;
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] private float destroyTime = 0.5f;

    private float timer;
    private List<GameObject> portalList;
    [SerializeField] private GameObject portal1Instant;
    [SerializeField] private GameObject portal2Instant;
    private int curr = 0;
    
    private GameObject CreatePortal(GameObject portal,Transform loc)
    {
        return Instantiate(portal, loc.position, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 99;
        curr = teleZones.Count-1;
        currState = State.createPortal1;
    }

    private GameObject token1;
    private GameObject token2;
    private bool canTele = true;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        switch (currState)
        {
            case State.createPortal1:
            {
                if (timer >= teleZones[curr].teleTime)
                {
                    token1 = CreatePortal(portal1Instant, teleZones[curr].Portal1Loc);
                    currState = State.createPortal2;
                }

                break;
            }
            case State.createPortal2:
            {
                if (timer >= teleZones[curr].teleTime + delayTime)
                {
                    token2 = CreatePortal(portal2Instant, teleZones[curr].Portal2Loc);
                    currState = State.linkPortals;
                }

                break;
            }
            case State.linkPortals:
            {
                token2.GetComponent<Portal>().portalOut = token1;
                token1.GetComponent<Portal>().portalOut = token2;

                token1.GetComponent<Portal>().willTele = true;
                token2.GetComponent<Portal>().willTele = true;
                // Debug.Log(token2.gameObject.GetComponent<Portal>().willTele);
                canTele = false;
                currState = State.destroyPortals;

                break;
            }
            case State.destroyPortals:
            {
                if (timer >= teleZones[curr].teleTime + delayTime + destroyTime)
                {
                    Destroy(token1);
                    Destroy(token2);
                    curr++;
                    canTele = true;
                    // reset curr to the start of the array
                    if (curr >= teleZones.Count)
                    {
                        curr = 0;
                    }

                    timer = 0;
                    currState = State.createPortal1;
                }
                break;
            }
            default:
            {
                Debug.Log("Unknown state");
                break;
            }
        }
    }
}
