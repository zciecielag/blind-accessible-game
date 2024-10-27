using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitAndSwitchScene : MonoBehaviour
{
    [SerializeField]
    private string sceneNameLoad;

    void Start()
    {
        
    }

    void Awake()
    {
        //Important thing to remember: Starting a coroutine doesn't
        //pause the whole script, it just waits inside the coroutine,
        //so the next instruction has to be put INSIDE the IEnumerator \/
        StartCoroutine(waiting());
    }

    void Update()
    {
        
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(sceneName:sceneNameLoad);
    }
}
