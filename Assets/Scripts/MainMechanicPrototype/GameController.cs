using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public bool gameStarted = false;
    public bool canStart;
    public GameObject clickText;
    public int objectsScrolled;
    public int totalObjects;
    public AudioSource audioSrc;

    void Start()
    {
        Instance = this;
        objectsScrolled = 0;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted && canStart)
        {
            if (audioSrc != null)
            {
                audioSrc.Play();
            }
            
            gameStarted = true;

            FadeAway fadeScript = clickText.GetComponent<FadeAway>();
            if (fadeScript != null)
            {
                fadeScript.StartFade();
            }
            else
            {
                clickText.SetActive(false);
            }

        }

    }

    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
