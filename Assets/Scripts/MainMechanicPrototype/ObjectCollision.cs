using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ObjectCollision : MonoBehaviour
{

    public TextMeshProUGUI scoreT;
    private AudioSource coinCollected;
    private GrabObject pressInput;

    public AudioSource failedToDodgeSound;
    public GameObject tryAgainPanel;
    public GameObject gameCompletedPanel;
    public int completionScore;
    private int scoreC = 0;
    public GameObject addObject;

    public GameObject debugCompleteGame;

    private void Start()
    {
        coinCollected = GetComponent<AudioSource>();
        pressInput = FindFirstObjectByType<GrabObject>();
        HealthManager.health = 3;

        if (debugCompleteGame != null) 
        {
            debugCompleteGame.GetComponent<Button>().onClick.AddListener(CompleteDebug);
        }
    }

    private void CompleteDebug()
    {
        scoreC = completionScore;
        scoreT.text = scoreC.ToString();
        StopAllCoroutines();
        StartCoroutine(WaitAndCompleteGame());
        scoreC = 0;
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
                Destroy(other.gameObject);
                if (scoreC == completionScore)
                {
                    StopAllCoroutines();
                    StartCoroutine(WaitAndCompleteGame());
                    scoreC = 0;
                }
            }

        } 
        else if(other.tag == "Cross")
        {
            HealthManager.health--;
            Destroy(other.gameObject);
            if(HealthManager.health <= 0)
            {
                StopAllCoroutines();
                StartCoroutine(WaitAndRestart());
                scoreC = 0;
            }
            else
            {
                failedToDodgeSound.Play();
            }
        }
    }

    IEnumerator WaitAndRestart()
    {
        GameController.Instance.gameStarted = false;

        if (tryAgainPanel != null)
        {
            tryAgainPanel.SetActive(true);
            Time.timeScale = 0f;
            float pauseEndTime = Time.realtimeSinceStartup + 3.0f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            Time.timeScale = 1f;
            //yield return new WaitForSeconds(5.0f);
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
            Time.timeScale = 0f;
            float pauseEndTime = Time.realtimeSinceStartup + 3.0f;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            Time.timeScale = 1f;
            //yield return new WaitForSeconds(3.0f);
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
