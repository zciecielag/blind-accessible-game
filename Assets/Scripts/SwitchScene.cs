using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int actId;
    public int questId;
    public string scene;
    private void OnEnable()
    {
        ActManager.Instance.AcquireQuest(actId, questId);
        GameSceneManager.Instance.ChangeName(scene);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(scene);
    }
}
