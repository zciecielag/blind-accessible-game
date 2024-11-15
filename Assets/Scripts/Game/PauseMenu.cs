using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    public GameObject settingsMenu;
    public GameObject inventory;
    public static bool isPaused;

    public GameObject joystick;
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
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
        joystick.SetActive(true);
        inventory.SetActive(true);
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

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
