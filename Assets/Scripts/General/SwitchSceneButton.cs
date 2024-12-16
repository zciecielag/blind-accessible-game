using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSceneButton : MonoBehaviour
{
    public string sceneNameLoad;

    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(loadScene);
    }

    void loadScene()
    {
        StartCoroutine(sceneLoadAndButtonSound()); 
    }

    IEnumerator sceneLoadAndButtonSound()
    {
        yield return new WaitForSeconds(0.2f);
        //audio src add
        SceneManager.LoadScene(sceneName: sceneNameLoad);
    }

}
