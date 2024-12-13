using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchSceneCompleteQuestWithCondition : MonoBehaviour, IGameDataManager
{
    public int actId;
    public int questId;
    public string sceneName;
    public AudioSource audioSource;
    public bool isEnabled;
    FadeInOut fadeInOut;
    public GameObject[] activateObjects;
    public string conditionalObjectTag;

    private void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        isEnabled = true;
        Debug.Log(gameObject.name + " got enabled");
        fadeInOut = FindFirstObjectByType<FadeInOut>();
    }

    public IEnumerator SwitchScene()
    {
        if (fadeInOut != null)
        {
            fadeInOut.FadeIn();
        }
        audioSource.Play();
        yield return new WaitForSeconds(1);
        GameSceneManager.Instance.ChangeName(sceneName);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(sceneName);

    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (isEnabled && conditionalObjectTag != null 
        && conditionalObjectTag == InventoryManager.Instance.currentlyHeldObject.tag)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            InventoryManager.Instance.RemoveFromInventory();

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

            StartCoroutine(SwitchScene());
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
