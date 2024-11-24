using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLane : MonoBehaviour
{
    //true - lewy przycisk
    //false - prawy przycisk
    public bool leftOrRight;
    public AudioSource failureSound;
    public AudioSource switchLaneSound;

    public GameObject character;
    //Instancja GlobalVariableManager będzie w każdym skrypcie gdzie chcemy użyć globalnych wartości w nim zapisanych
    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();
    private bool doubleTouch = false;

    private float touchDelay = 0.2f;
    private float lastMove = -Mathf.Infinity;

    //Ogólnie tu gdzieś trzeba zrobić algorytm który sprawdza czy 2 przyciski (tory) są naciśnięte dokładnie w tym samym czasie
    //I wtedy np. zrobić global variable bool jakiś na true, i wtedy wykorzystać to w skrypcie z kolizją że tak, gracz ma naciśnięte 2 na raz i chce złapać
    //Może da się to zrobić używając buttonPressCount z klasy GlobalVariableManager i sprawdzać czy jest równy 2,
    //ale wtedy wchodzi problem z tym że program nie może czekać na naciśnięcie 2 przycisku i jak jest tylko 1 naciśnięty
    //to postać musi się poruszyć. I tak samo trzeba ogarnąć jak zrobić żeby przy naciśnięciu 2 przycisków na raz postać stoi w miejscu,
    //bo to jest akcja łapania obiektu
    //Ewentualnie osobny skrypt jeszcze na to

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && Time.time >= lastMove)
            {
                StartCoroutine(WaitForDoubleTouch(touch));
            }
        }
    }
    private IEnumerator WaitForDoubleTouch(Touch initialTouch)
    {
        doubleTouch = true;
        yield return new WaitForSeconds(touchDelay);

        if(Input.touchCount > 1) 
        { 
        }
        else// nie wykryto drugiego przyciśnięcia = zmień miejsce
        {
            float screenWidth = Screen.width;
            if(initialTouch.position.x < screenWidth/2)  // dotkniecie lewej strony
            {
                SwitchToLeftLine();
            } 
            else
            {
                SwitchToRightLine();
            }
        }
        doubleTouch = false; //reset flagi
        lastMove = Time.time;
    }

    private void SwitchToLeftLine()
    {
        if (character.transform.position.x == -4.8f)
        {
            Debug.Log("Can't move further left");
            failureSound.Play();
        }
        else
        {
            switchLaneSound.Play();
            //Ruszamy kotka w lewo, czas jest max więc od razu się rusza
            character.transform.position = new Vector3(-4.8f, -3.92f, 1f * Time.deltaTime);
        }
    }

    private void SwitchToRightLine()
    {
        if (character.transform.position.x == 5.1f)
        {
            Debug.Log("Can't move further right");
            failureSound.Play();
        }
        else
        {
            switchLaneSound.Play();
            //Ruszamy kotka w prawo, czas jest max więc od razu się rusza
            character.transform.position = new Vector3(5.1f, -3.92f, 1f * Time.deltaTime);
        }
    }
}
