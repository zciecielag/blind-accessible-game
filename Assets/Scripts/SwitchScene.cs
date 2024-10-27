using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{

    [SerializeField]
    private string sceneNameLoad;

    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(loadScene);
    }

    void Update()
    {
        
    }

    void loadScene()
    {
        SceneManager.LoadScene(sceneName: sceneNameLoad);
    }

}
