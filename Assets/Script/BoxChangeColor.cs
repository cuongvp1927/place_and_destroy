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
    private int curr;

    void changePrefab(GameObject nextPrefab)
    {
        // deactivate anyother prefab
        foreach (var box in colorBoxes)
        {
            if (!box.preFab.CompareTag("Objective"))
            {                
                box.preFab.SetActive(false);
            }
        }

        // to activate the prefab
        nextPrefab.SetActive(true);;

    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        curr = 0;
        // deactivate anyother prefab
        foreach (var box in colorBoxes)
        {
            if (!box.preFab.CompareTag("Objective"))
            {
                box.preFab.SetActive(false);
            }
        }
        /// activate the original prefab
        colorBoxes[0].preFab.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= colorBoxes[curr].nextTimer)
        {
            changePrefab(colorBoxes[curr].preFab);
            curr++;
            if (curr >= colorBoxes.Count)
            {
                curr = 0;
            }
            timer = 0;
        }

    }
}
