using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public GameObject settingsMenu;
    public GameObject inventory;
    public static bool isPaused;

    public GameObject joystick;
    public GameObject menuButton;
    public GameObject whichRoomButton;
    public GameObject whichRoomButtonQuest;

    public GameObject[] activeDialogue;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        joystick.SetActive(false);
        inventory.SetActive(false);
        menuButton.SetActive(false);

        activeDialogue = GameObject.FindGameObjectsWithTag("DialogueBox");
        if (activeDialogue != null)
        {
            foreach(GameObject a in activeDialogue)
            {
                a.SetActive(false);
            }
        }

        if (whichRoomButton != null)
        {
            whichRoomButton.SetActive(false);
        }
        if (whichRoomButtonQuest != null && whichRoomButtonQuest.GetComponent<EnableableObject>().GetEnabledStatus())
        {
            whichRoomButton.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        joystick.SetActive(true);
        inventory.SetActive(true);
        menuButton.SetActive(true);

        if (activeDialogue != null)
        {
            foreach(GameObject a in activeDialogue)
            {
                a.SetActive(true);
            }
        }

        if (whichRoomButton != null)
        {
            whichRoomButton.SetActive(true);
        }
        if (whichRoomButtonQuest != null && whichRoomButtonQuest.GetComponent<EnableableObject>().GetEnabledStatus())
        {
            whichRoomButton.SetActive(true);
        }
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SaveGame()
    {
        GameDataManager.Instance.SaveGame();
    }

    public void LoadGame()
    {
        GameDataManager.Instance.LoadGame();
    }

    public void GoToSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void GoToPauseMenu()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene("GameMainMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameDataManager.Instance.SaveGame();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    //debug
    public void NewGame()
    {
        GameDataManager.Instance.NewGame();
    }
}
