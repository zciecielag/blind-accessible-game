using UnityEngine;

public class ObjectsScrolling : MonoBehaviour
{
    public float tempo;

    //Na przyszłość, żeby nie zaczynać scrollowania od razu tylko poczekać jak np. gracz kliknie żeby zacząć
    private GameController gameController;

    void Start()
    {
        gameController = FindFirstObjectByType<GameController>();

        //Jakby co nie wiem czemu taka matematyka tempa, tak było w tutorialu XD
        tempo = tempo / 60f;
    }

    //Tutaj scrollujemy wszystkie obiekty pod FallingObjects w jakimś tempie 
    void Update()
    {
        if (gameController != null && gameController.gameStarted)
        {
            transform.position -= new Vector3(0f, tempo * Time.deltaTime, 0f);
        }
    }
}
