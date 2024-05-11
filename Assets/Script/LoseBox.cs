using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseBox : MonoBehaviour
{
    private bool isLose = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "moveable")
        {
            isLose = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLose)
        {
            GameMasterSingleton.Instance.PlaySFX("Lose");
            GameMasterSingleton.Instance.LoadNewScene("LoseScene");
        }
    }
}
