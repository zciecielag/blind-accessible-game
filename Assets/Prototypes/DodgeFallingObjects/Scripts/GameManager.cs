using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> fallingObjects; 
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate; // jak szybko bed¹ siê spawnowa³y spadaj¹ce obiekty

    bool gameStarted = false;

    public GameObject clickText;
    public TextMeshProUGUI scoreT;

    int scoreC = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !gameStarted)// kiedy klikniemy na ekran i gra sie jeszcze sie nie zaczê³a
        {
            StartSpawn(); //zaczynamy spawnowac
            gameStarted = true;
       
            clickText.SetActive(false);

        } 
    }

    private void StartSpawn()
    {
        InvokeRepeating("SpawnBlock", 3f, spawnRate);
    }
    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position; // odnosimy sie do naszego Spawn pointu
        spawnPos.x = Random.Range(-maxX, maxX);

        int randomIndex = Random.Range(0, fallingObjects.Count);
        GameObject Random_Falling_Object = fallingObjects[randomIndex];

        Instantiate(Random_Falling_Object, spawnPos, Quaternion.identity);

        scoreC++;
        scoreT.text = scoreC.ToString();
        
    }

}
