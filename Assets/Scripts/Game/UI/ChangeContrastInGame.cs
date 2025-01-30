using System.Collections.Generic;
using UnityEngine;

public class ChangeContrastInGame : MonoBehaviour
{
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private ChangeImageContrast[] objects;

    void Start()
    {
        SwitchToContrast();
    }

    public void SwitchToContrast()
    {
        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].ChangeContrast();
        }

        if (globalVariableManager.GetContrastStatus())
        {
            FindAnyObjectByType<CheckIfContrast>().ChangeToContrast();
        }
        else
        {
            FindAnyObjectByType<CheckIfContrast>().ChangeToNoContrast();
        }

        GameObject.FindGameObjectWithTag("Player")
        .GetComponent<PlayerMovement>()
        .animator
        .SetBool("Contrast", globalVariableManager.GetContrastStatus());

        Debug.Log("Contrast value is: " + globalVariableManager.GetContrastStatus());

    }

    public void ToggleContrast()
    {
        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);
        globalVariableManager.SetContrastStatus(!globalVariableManager.GetContrastStatus());

        for (int i = 0; i < objects.Length; i++)
        {
            if (globalVariableManager.GetContrastStatus())
            {
                objects[i].ChangeToContrast();
            }
            else
            {
                objects[i].ChangeToNoContrast();
            }
        }

        if (globalVariableManager.GetContrastStatus())
        {
            FindAnyObjectByType<CheckIfContrast>().ChangeToContrast();
        }
        else
        {
            FindAnyObjectByType<CheckIfContrast>().ChangeToNoContrast();
        }

        GameObject.FindGameObjectWithTag("Player")
        .GetComponent<PlayerMovement>()
        .animator
        .SetBool("Contrast", globalVariableManager.GetContrastStatus());

        Debug.Log("Contrast value was changed to: " + globalVariableManager.GetContrastStatus());
    }
}
