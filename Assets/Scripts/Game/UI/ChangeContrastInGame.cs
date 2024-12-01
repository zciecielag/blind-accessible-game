using System.Collections.Generic;
using UnityEngine;

public class ChangeContrastInGame : MonoBehaviour
{
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private GameObject[] buttons;
    private GameObject[] objects;

    void Start()
    {
        //Trzeba do buttonów w panelach w UI dodać skrypty zmieniające sprite

        //buttons = GameObject.FindGameObjectsWithTag("Button");
        objects = GameObject.FindGameObjectsWithTag("Object");
    }

    public void ToggleContrast()
    {
        globalVariableManager.SetContrastStatus(!globalVariableManager.GetContrastStatus());

        // for (int i = 0; i < buttons.Length; i++)
        // {
        //     buttons[i].GetComponent<ChangeButtonContrast>().changeContrast();
        // }

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].GetComponent<ChangeImageContrast>().changeContrast();
        }

        Debug.Log("Contrast value was changed to: " + globalVariableManager.GetContrastStatus());
    }
}
