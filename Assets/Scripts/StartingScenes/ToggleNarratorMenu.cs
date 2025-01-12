using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class ToggleNarratorMenu : MonoBehaviour
{
    public AudioMixer mixer;
    private float volume;
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(DoSwitchNarrator);
    }

    private void DoSwitchNarrator()
    {
        mixer.GetFloat("vol", out volume);
        if (volume == -80.0f)
        {
            mixer.SetFloat("vol", -20.0f);
        } else {
            mixer.SetFloat("vol", -80.0f);
        }
    }
}
