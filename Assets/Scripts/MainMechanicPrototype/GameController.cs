using UnityEngine;


public class GameController : MonoBehaviour
{
    //Ogólny skrypt do gry, tutaj można np. sprawdzać czy piosenka się skończyła i jak tak to wychodzić z aplikacji
    //Ogólnie rzeczy które nie pasują do innych skryptów
    //Lub co tam wymyślicie

    public bool gameStarted = false;
    public bool canStart = false;
    public GameObject clickText;
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted && canStart)// kiedy klikniemy na ekran i gra sie jeszcze sie nie zaczęła
        {
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
}
