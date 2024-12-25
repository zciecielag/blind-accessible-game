using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour, IGameDataManager
{

    private string currentSceneName;
    public static GameSceneManager Instance 
    { 
        get; 
        private set; 
    }

    public void LoadData(GameData data)
    {
        this.currentSceneName = data.currentSceneName;
        if (SceneManager.GetActiveScene().name != currentSceneName) { SceneManager.LoadScene(currentSceneName); }
    }

    public void SaveData(ref GameData data)
    {
        data.currentSceneName = this.currentSceneName;
    }

    private void Start()
    {
        Instance = this;
        this.currentSceneName = SceneManager.GetActiveScene().name;
    }

    public void ChangeName(string name)
    {
        this.currentSceneName = name;
    }

}
