using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneCompleteQuest : MonoBehaviour
{
    public int questId;
    public string sceneName;
    private void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        gameObject.GetComponent<AudioSource>().Stop();
        ActManager.Instance.CompleteSubQuest(questId);
        GameSceneManager.Instance.ChangeName(sceneName);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(sceneName);
    }
}
