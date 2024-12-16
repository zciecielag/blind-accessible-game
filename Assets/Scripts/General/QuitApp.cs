using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitApp : MonoBehaviour
{
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
