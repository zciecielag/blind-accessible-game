using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ChangeButtonContrast : MonoBehaviour
{
    
    public Sprite contrastImage;
    public Sprite noContrastImage;
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();

    void Start()
    {
        var buttonImage = gameObject.GetComponent<Image>();
        Debug.Log(globalVariableManager.GetContrastStatus());
        if (globalVariableManager.GetContrastStatus())
        {
            buttonImage.sprite = contrastImage;
        } else 
        {
            buttonImage.sprite = noContrastImage;
        }
        
    }


    void Update()
    {
        
    }
}
