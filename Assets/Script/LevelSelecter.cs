using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour
{
    public void level1()
    {
        SceneManager.LoadScene("Level 1");

    }
    public void level2()
    {
        SceneManager.LoadScene("Level_2");

    }

    public void level3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void level4()
    {
        SceneManager.LoadScene("Level4Scn");
    }

    public void levelTutorial()
    {
        SceneManager.LoadScene("Tutorial Scn");
    }
    public void levelSelectScn()
    {
        SceneManager.LoadScene("LevelSelectScn");
    }
}
