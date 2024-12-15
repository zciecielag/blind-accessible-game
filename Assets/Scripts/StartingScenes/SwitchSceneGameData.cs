using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneGameData : MonoBehaviour
{
    public void CreateNewGame()
    {
        GameDataManager.Instance.NewGame();
        SceneManager.LoadScene(sceneName: GameDataManager.Instance.GetGameData().currentSceneName);
    }

    public void LoadGame()
    {
        GameDataManager.Instance.LoadGame();

        if (GameDataManager.Instance.GetGameData().currentActId == 0 && GameDataManager.Instance.GetGameData().currentSubQuestId < 6)
        {
            Debug.Log("Nie mozna wczytac danych z samouczka, zacznie sie nowa gra.");
            CreateNewGame();
        }
        else
        {
             SceneManager.LoadScene(sceneName: GameDataManager.Instance.GetGameData().currentSceneName);
        }
    }
       
}
