using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private string previousSceneName;

    void Start()
    {

    }

    // �ڳ����л�ʱ���ã����浱ǰ������������Ϊ��һ������������
    void OnDisable()
    {
        PlayerPrefs.SetString("PreviousScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
