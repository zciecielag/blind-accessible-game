using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlVolume : MonoBehaviour
{
    [SerializeField]
    private bool upOrDown;
    
    private bool canChangeUp;
    private bool canChangeDown;

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();

    void Start()
    {
        canChangeDown = true;
        canChangeUp = true;
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(DoControlVolume);
    }
    
    void DoControlVolume()
    {
        canChangeDown = true;
        canChangeUp = true;
        var volumeF = globalVariableManager.GetGeneralVolume();
        double volume = (double) volumeF;
        if (volume <= 0)
        {
            canChangeDown = false;
        } else if (volume >= 1)
        {
            canChangeUp = false;
        }
        if (upOrDown)
        {
            // globalVariableManager.SetGeneralVolumeChange(0.1f);
            // globalVariableManager.SetIsVolumeChanged(true);
            // Debug.Log(globalVariableManager.GetGeneralVolumeChange());
            // Debug.Log(globalVariableManager.GetIsVolumeChanged());
            if (canChangeUp && (volume+0.1 <= 1))
            {
                volume = volume + 0.1;
                volumeF = (float) volume;
                globalVariableManager.SetGeneralVolume(volumeF);
            }
        } else 
        {
            // globalVariableManager.SetGeneralVolumeChange(-0.1f);
            // globalVariableManager.SetIsVolumeChanged(true);
            // Debug.Log(globalVariableManager.GetGeneralVolumeChange());
            // Debug.Log(globalVariableManager.GetIsVolumeChanged());
            if (canChangeDown && (volume-0.1 >= 0.0))
            {
                volume = volume - 0.1;
                volumeF = (float) volume;
                globalVariableManager.SetGeneralVolume(volumeF);
            }

        }
        
    }
}
