using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TrapSawRotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    [SerializeField] private float speed = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
