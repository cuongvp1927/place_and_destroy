using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoseBox : MonoBehaviour
{
    private bool isLose = false;

    // Start is called before the first frame update
    void Start()
    {
    
    }

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
        // when is lose is true;

        if (isLose)
        {
            Debug.Log("You lose");
            // string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("LoseScene");
        }
    }
}
