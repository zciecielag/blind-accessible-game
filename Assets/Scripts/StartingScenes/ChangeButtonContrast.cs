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
        changeContrast();
    }

    public void changeContrast()
    {
        var buttonImage = gameObject.GetComponent<Image>();
        if (globalVariableManager.GetContrastStatus())
        {
            buttonImage.sprite = contrastImage;
        } else 
        {
            buttonImage.sprite = noContrastImage;
        }
    }
}
