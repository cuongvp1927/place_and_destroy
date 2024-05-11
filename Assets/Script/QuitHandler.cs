using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    [SerializeField] private GameObject NoBox;
    [SerializeField] private GameObject FirstBox;

    public void ShowNoBox()
    {
        FirstBox.SetActive(false);
        NoBox.SetActive(true);
        Destroy(gameObject);
    }

    private void Start()
    {
        FirstBox.SetActive(true);
        NoBox.SetActive(false);
    }
}
