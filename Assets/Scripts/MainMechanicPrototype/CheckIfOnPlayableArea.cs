using System.Collections;
using UnityEngine;

public class CheckIfOnPlayableArea : MonoBehaviour
{
    private AudioSource objectSound;
    public GameObject tryAgainPanel;
    private void Awake()
    {
        objectSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "GameField")
        {
            objectSound.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "GameField")
        {
            Debug.Log(this.gameObject.name + " Has exited GameField");
            objectSound.Stop();
            GameController.Instance.objectsScrolled++;
            if (GameController.Instance.objectsScrolled == GameController.Instance.totalObjects)
            {
                GameController.Instance.objectsScrolled = 0;       
                StopAllCoroutines();    
                StartCoroutine(WaitAndRestart());
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
}
