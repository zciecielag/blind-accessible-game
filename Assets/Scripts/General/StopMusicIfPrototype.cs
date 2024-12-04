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
        //Trzeba to bedzie zmienic na bardziej efektywne XD
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "MainScene" || SceneManager.GetActiveScene().name == "Cutscene.01.StartCutscene")
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
