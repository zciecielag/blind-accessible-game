using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneCompleteQuest : MonoBehaviour, IGameDataManager
{
    public int actId;
    public int questId;
    public string sceneName;
    public bool isEnabled;
    public GameObject[] activateObjects;

    private void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        isEnabled = true;
        Debug.Log("got enabled");
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isEnabled)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            if (questId > 0)
            {
                ActManager.Instance.CompleteSubQuest(actId, questId);
            }
            GameSceneManager.Instance.ChangeName(sceneName);
            isEnabled = false;

            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                }
            }

            GameDataManager.Instance.SaveGame();
            SceneManager.LoadScene(sceneName);
        }  
    }

    public void LoadData(GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            this.isEnabled = data.enabledGameObjects[this.gameObject.tag];
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            data.enabledGameObjects[this.gameObject.tag] = this.isEnabled;
        }
        else
        {
            data.enabledGameObjects.Add(this.gameObject.tag, isEnabled);
        }
    }
}
