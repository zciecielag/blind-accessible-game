using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchContrast : MonoBehaviour
{
    //True if the button chooses contrast; False if otherwise
    [SerializeField]
    private bool contrastOrNoContrast;

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(DoSwitchContrastAndLoadNext);
    }

    void Update()
    {
        
    }

    void DoSwitchContrastAndLoadNext()
    {
        globalVariableManager.SetContrastStatus(contrastOrNoContrast);
        Debug.Log("Current contrast status: " + globalVariableManager.GetContrastStatus());
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
