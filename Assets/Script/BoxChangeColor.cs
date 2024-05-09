using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxChangeColor : MonoBehaviour
{

    [System.Serializable]
    public struct colorBox
    {
        public float nextTimer;
        public GameObject preFab;
    }

    public List<colorBox> colorBoxes;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


    }
}
