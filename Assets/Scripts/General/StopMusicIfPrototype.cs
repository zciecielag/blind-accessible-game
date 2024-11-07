using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMusicIfPrototype : MonoBehaviour
{
    private bool paused;

    void Start()
    {
        paused = false;
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "MainScene")
        {
            this.gameObject.GetComponent<AudioSource>().Pause();
            paused = true;
        } else 
        {
            if (paused)
            {
                this.gameObject.GetComponent<AudioSource>().UnPause();
                paused = false;
            }
        }
    }
}
