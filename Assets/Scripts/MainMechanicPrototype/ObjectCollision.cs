using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ObjectCollision : MonoBehaviour
{

    public TextMeshProUGUI scoreT;
    public GameObject characterKot;
    private AudioSource coinCollected;
    private GrabObject pressInput;

    public AudioSource failedToDodgeSound;
    public GameObject tryAgainPanel;
    public GameObject gameCompletedPanel;
    public int completionScore;
    public int scoreC = 0;
    public GameObject addObject;


    private void Start()
    {
        characterKot = GetComponent<GameObject>();
        coinCollected = GetComponent<AudioSource>();
        pressInput = FindFirstObjectByType<GrabObject>();
        HealthManager.health = 3;
    }

    void Update()
    {
        if (scoreC == completionScore)
        {
            StartCoroutine(WaitAndCompleteGame());
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Circle")
        {
            if (pressInput != null && pressInput.leftRightPressed)
            {
                coinCollected.Play();
                scoreC++;
                scoreT.text = scoreC.ToString();
                if (scoreC == completionScore)
                {
                    StartCoroutine(WaitAndCompleteGame());
                }
                Destroy(other.gameObject);
            }

        } 
        else if(other.tag == "Cross")
        {
            HealthManager.health--;
            if(HealthManager.health <= 0)
            {
                StartCoroutine(WaitAndRestart());
            }
            else
            {
                failedToDodgeSound.Play();
            }
            Destroy(other.gameObject);
        }
    }

    IEnumerator WaitAndRestart()
    {
        GameController.Instance.gameStarted = false;

        if (tryAgainPanel != null)
        {
            tryAgainPanel.SetActive(true);
            yield return new WaitForSeconds(4.0f);
            tryAgainPanel.SetActive(false);
        }
        
        GameController.Instance.RestartGame();
    }

    IEnumerator WaitAndCompleteGame()
    {
        GameController.Instance.gameStarted = false;

        if (gameCompletedPanel != null)
        {
            gameCompletedPanel.SetActive(true);
            yield return new WaitForSeconds(5.0f);
            gameCompletedPanel.SetActive(false);
        }

        ActManager.Instance.AcquireQuest(1, 8);
        GameSceneManager.Instance.ChangeName("Scene.01.05.Pantry");
        if (addObject != null)
        {
            InventoryManager.Instance.AddToInventory(addObject);
        }
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene("Scene.01.05.Pantry");
    }
}
