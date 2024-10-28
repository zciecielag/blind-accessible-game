using UnityEngine;

public class DontDestroyAudioSrc : MonoBehaviour
{
    void Awake()
    {
        GameObject[] audioSrc = GameObject.FindGameObjectsWithTag("musicSource");
        if (audioSrc.Length > 1)
        {
            Destroy(this.gameObject);
        } else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
}
