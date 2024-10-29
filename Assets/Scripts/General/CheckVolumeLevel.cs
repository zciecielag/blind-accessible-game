using UnityEngine;

public class CheckVolumeLevel : MonoBehaviour
{

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();

    void Update()
    {
        if (globalVariableManager.GetGeneralVolume() >= 0){
            this.gameObject.GetComponent<AudioSource>().volume = globalVariableManager.GetGeneralVolume();
        }
    }
}
