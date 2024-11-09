using UnityEngine;

public class CheckIfOnPlayableArea : MonoBehaviour
{
    //Zuzia
    //Tu jest taki skrypt dodatkowy, w sumie nie wiem czy go potrzebujemy i czy w taki sposób
    //Ale ogólnie myślałam żeby zrobić dodatkowe sprawdzanie czy obiekt ma kolizję z Backgroundem (lub można dodać inny obiekt, może troche wyżej nawet?)
    //I wtedy dopiero gra jego dźwięk
    //Żeby nie od razu wszystkie na raz grały jak spadają bo może się mieszać

    //Kasia
    //Masz racje tu, mozna sprobowac dodac game field i wtedy dopiero sprawdzac collision z tym(latwiej by tak bylo mi sie wydaje
    private AudioSource objectSound;
    //bool isPlaying;
    private void Awake()
    {
        objectSound = GetComponent<AudioSource>();//pobieramy dzwieki
        //isPlaying = false;
        //AudioSource circleSound = GameObject.FindGameObjectWithTag("Circle").GetComponent<AudioSource>();
    }
    //problem, dzwieki sie mieszaja duzo i ciezko grac
    private void OnTriggerEnter2D(Collider2D other)
    {
        //co się dzieje kiedy wchodzimy w kolizję
        if (other.gameObject.name == "GameField")
        {
            //isPlaying = true;
            objectSound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //co się dzieje kiedy wychodzimy z tej kolizji
        if (other.gameObject.name == "GameField")
        {
            //isPlaying = false;
            objectSound.Stop();
        }
    }
}
