using UnityEngine;

public class CheckVolumeLevel : MonoBehaviour
{

    private GlobalVariableManager globalVariableManager;
    private float volume;
    private double volumeD;
    private float volumeChange;
    private double volumeChangeD;

    private bool canChange;

    void Start()
    {
        globalVariableManager = new GlobalVariableManager();
    }

    void Update()
    {
        // if (globalVariableManager.GetIsVolumeChanged())
        // {
        //     volume = this.gameObject.GetComponent<AudioSource>().volume;
        //     volumeChange = globalVariableManager.GetGeneralVolumeChange();
        //     volumeD = (double) volume;
        //     volumeChangeD = (double) volumeChange;
        //     Debug.Log(volumeD);
        //     Debug.Log(volumeChangeD);

        //     //canChange = true;
        //     if ((volumeD + volumeChangeD) <= 1 && (volumeD + volumeChangeD) >= 0)
        //     {
        //         volumeD += volumeChangeD;
        //         this.gameObject.GetComponent<AudioSource>().volume = (float) volumeD;
        //     }
        //     else
        //     {
        //         //canChange = false;
        //     }
        //     globalVariableManager.SetIsVolumeChanged(false);
        // }
        
        if (globalVariableManager.GetGeneralVolume() >= 0){
            this.gameObject.GetComponent<AudioSource>().volume = globalVariableManager.GetGeneralVolume();
        }
    }
}
