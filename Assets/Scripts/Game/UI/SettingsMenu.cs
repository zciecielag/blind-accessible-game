using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject chooseSettings;
    public GameObject volumeModification;
    public GameObject brightnessModification;
    public GameObject switchContrast;

    public void ShowVolumeModification()
    {
        chooseSettings.SetActive(false);
        volumeModification.SetActive(true);
    }

    public void VolumeGoBack()
    {
        volumeModification.SetActive(false);
        chooseSettings.SetActive(true);
    }

    public void ShowBrightnessModification()
    {
        chooseSettings.SetActive(false);
        brightnessModification.SetActive(true);
    }

    public void BrightnessGoBack()
    {
        brightnessModification.SetActive(false);
        chooseSettings.SetActive(true);
    }

    public void ShowSwitchContrast()
    {
        chooseSettings.SetActive(false);
        switchContrast.SetActive(true);
    }

    public void ContrastGoBack()
    {
        switchContrast.SetActive(false);
        chooseSettings.SetActive(true);
    }



    
}
