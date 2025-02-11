using System.Collections.Generic;
using UnityEngine;

public class ChangeContrastInGame : MonoBehaviour
{
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private ChangeImageContrast[] objects;
    private ChangeButtonContrast[] buttons;

    void Start()
    {
        SwitchToContrast();
    }

    public void SwitchToContrast()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null 
        && GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>() != null)
        {
            GameObject.FindGameObjectWithTag("Player")
            .GetComponent<PlayerMovement>()
            .animator
            .SetBool("Contrast", globalVariableManager.GetContrastStatus());
        }

        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);

        if (objects != null)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].ChangeContrast();
            }
        }

        buttons = FindObjectsByType<ChangeButtonContrast>(FindObjectsSortMode.None);
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].changeContrast();
            }
        }

        if (FindAnyObjectByType<CheckIfContrast>() != null)
        {
            if (globalVariableManager.GetContrastStatus())
            {
                FindAnyObjectByType<CheckIfContrast>().ChangeToContrast();
            }
            else
            {
                FindAnyObjectByType<CheckIfContrast>().ChangeToNoContrast();
            }
        }
        
        Debug.Log("Contrast value is: " + globalVariableManager.GetContrastStatus());

    }

    public void ToggleContrast()
    {
        objects = FindObjectsByType<ChangeImageContrast>(FindObjectsSortMode.None);
        globalVariableManager.SetContrastStatus(!globalVariableManager.GetContrastStatus());

        
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>() != null)
            {
                GameObject.FindGameObjectWithTag("Player")
                .GetComponent<PlayerMovement>()
                .animator
                .SetBool("Contrast", globalVariableManager.GetContrastStatus());
            }
        }
        
        if (objects != null)
        {
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
        }

        buttons = FindObjectsByType<ChangeButtonContrast>(FindObjectsSortMode.None);
        if (buttons != null)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].changeContrast();
            }
        }
        
        if (FindAnyObjectByType<CheckIfContrast>() != null)
        {
            if (globalVariableManager.GetContrastStatus())
            {
                FindAnyObjectByType<CheckIfContrast>().ChangeToContrast();
            }
            else
            {
                FindAnyObjectByType<CheckIfContrast>().ChangeToNoContrast();
            }
        }

        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.ChangeItemContrast();
        }

        Debug.Log("Contrast value was changed to: " + globalVariableManager.GetContrastStatus());
    }
}
