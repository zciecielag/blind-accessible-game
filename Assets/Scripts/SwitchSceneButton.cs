using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSceneButton : MonoBehaviour
{

    [SerializeField]
    private string sceneNameLoad;

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
        SceneManager.LoadScene(sceneName: sceneNameLoad);
    }

}
