using UnityEngine;

public class DontDestroyAudioSrc : MonoBehaviour
{
    void Awake()
    {
        // GameObject[] audioSrc = GameObject.FindGameObjectsWithTag("");
        // if (audioSrc.Length > 1)
        // {
        //     Destroy(this.gameObject);
        // } else
        // {
            DontDestroyOnLoad(this.gameObject);
        //}
        
    }
}
