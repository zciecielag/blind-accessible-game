using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ObjectCollision : MonoBehaviour
{
    //Tutaj trzeba zrobić kolizję z kotkiem i co wtedy się dzieje
    //Dodatkowo połączenie ze skryptem, gdzie będzie sprawdzanie czy w danym momencie gracz kliknął 2 przyciski jednocześnie
    //Wtedy albo jupi sukces + dźwięk albo nie udało nam się :(

    //true - circle
    //false - cross
    //i trzeba ify porobić co jeśli circle co jeśli cross

    public TextMeshProUGUI scoreT;
    public GameObject characterKot;
    private AudioSource coinCollected;
    private GrabObject pressInput;

    public AudioSource failedToDodgeSound;
    int scoreC = 0;


    private void Awake()
    {
        characterKot = GetComponent<GameObject>();
        coinCollected = GetComponent<AudioSource>();
        pressInput = FindFirstObjectByType<GrabObject>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //co się dzieje kiedy wchodzimy w kolizję z kotkiem
        if (other.tag == "Circle")
        {
            if (pressInput != null && pressInput.leftRightPressed)
            {
                // Złapanie przedmiotu
                coinCollected.Play();
                scoreC++;
                scoreT.text = scoreC.ToString();
                Destroy(other.gameObject);
            }

        } 
        else if(other.tag == "Cross")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                HealthManager.health = 3;
            }
            else
            {
                failedToDodgeSound.Play();
            }
            Destroy(other.gameObject);
        }
    }
}
