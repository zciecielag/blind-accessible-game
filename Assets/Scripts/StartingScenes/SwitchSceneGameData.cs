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
        SceneManager.LoadScene(sceneName: GameDataManager.Instance.GetGameData().currentSceneName);
    }
}
