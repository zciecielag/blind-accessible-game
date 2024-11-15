using UnityEngine;
using UnityEngine.Audio;

public class ControlVolume : MonoBehaviour
{
    [SerializeField] private AudioMixer musicMixer;
    private float currentVolume;
    private double currentVolumeD;
    
    public void IncreaseVolume()
    {
        musicMixer.GetFloat("vol", out currentVolume);
        currentVolumeD = (double) currentVolume;
        Debug.Log(currentVolume);
        Debug.Log(currentVolumeD);

        //Way too loud at +20dB so there'a a cap
        if (currentVolume + 10 > 0) 
        {
            Debug.Log("Cannot increase volume");
        }
        else
        {
            currentVolumeD += 10;
            currentVolume = (float) currentVolumeD;
            musicMixer.SetFloat("vol", currentVolume);
        }
    }

    public void DecreaseVolume()
    {
        musicMixer.GetFloat("vol", out currentVolume);
        currentVolumeD = (double) currentVolume;
        Debug.Log(currentVolume);
        Debug.Log(currentVolumeD);
        
        if (currentVolume - 10 < -80) 
        {
            Debug.Log("Cannot decrease volume");
        }
        else
        {
            currentVolumeD -= 10;
            currentVolume = (float) currentVolumeD;
            musicMixer.SetFloat("vol", currentVolume);
        }
    }

    public void SetVolume(float volume)
    {
        musicMixer.SetFloat("vol", volume);
    }
}
