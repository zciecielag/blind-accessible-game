using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndSwitchScene : MonoBehaviour
{
    [SerializeField]
    private string sceneNameLoad;

    void Awake()
    {
        StartCoroutine(waiting());
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(sceneName:sceneNameLoad);
    }
}
