using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject chooseSettings;
    public GameObject volumeModification;
    public GameObject switchContrast;
    public GameObject switchNarrator;

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

    public void ShowSwichNarrator()
    {
        chooseSettings.SetActive(false);
        switchNarrator.SetActive(true);
    }

    public void NarratorGoBack()
    {
        switchNarrator.SetActive(false);
        chooseSettings.SetActive(true);
    }



    
}
