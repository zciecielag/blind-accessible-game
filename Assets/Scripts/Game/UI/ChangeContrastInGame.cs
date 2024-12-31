using System.Collections.Generic;
using UnityEngine;

public class ChangeContrastInGame : MonoBehaviour
{
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private ChangeButtonContrast[] buttons;
    private ChangeImageContrast[] objects;

    void Start()
    {
        //Trzeba do buttonów w panelach w UI dodać skrypty zmieniające sprite

        //buttons = FindObjectsByType<ChangeButtonContrast>(FindObjectsSortMode.None);
        //objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);

        SwitchToContrast();
    }

    public void SwitchToContrast()
    {
        //buttons = FindObjectsByType<ChangeButtonContrast>(FindObjectsSortMode.None);
        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);

        // for (int i = 0; i < buttons.Length; i++)
        // {
        //     buttons[i].GetComponent<ChangeButtonContrast>().changeContrast();
        // }

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].changeContrast();
        }

        Debug.Log("Contrast value is: " + globalVariableManager.GetContrastStatus());

    }

    public void ToggleContrast()
    {
        //buttons = FindObjectsByType<ChangeButtonContrast>(FindObjectsSortMode.None);
        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);
        globalVariableManager.SetContrastStatus(!globalVariableManager.GetContrastStatus());

        // for (int i = 0; i < buttons.Length; i++)
        // {
        //     buttons[i].GetComponent<ChangeButtonContrast>().changeContrast();
        // }

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].changeContrast();
        }

        Debug.Log("Contrast value was changed to: " + globalVariableManager.GetContrastStatus());
    }
}
