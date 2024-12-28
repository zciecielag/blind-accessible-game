using UnityEngine;
using UnityEngine.UI;
public class ToggleContrastMenu : MonoBehaviour
{

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
   
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(DoSwitchContrast);
    }

    void DoSwitchContrast()
    {
        globalVariableManager.SetContrastStatus(!globalVariableManager.GetContrastStatus());
    }
}
