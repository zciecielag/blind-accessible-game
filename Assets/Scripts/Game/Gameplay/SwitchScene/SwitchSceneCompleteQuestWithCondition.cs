using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchSceneCompleteQuestWithCondition : MonoBehaviour
{
    public int actId;
    public int questId;
    public string sceneName;
    public AudioSource audioSource;
    FadeInOut fadeInOut;
    public GameObject[] activateObjects;
    public string conditionalObjectTag;
    public string spawnPointTag;

    private void OnEnable()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<EnableableObject>().Enable();
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
        PlayerSpawnPoint.Instance.ChangeSpawnPoint(spawnPointTag);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(sceneName);

    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (gameObject.GetComponent<EnableableObject>().GetEnabledStatus() && conditionalObjectTag != null 
        && conditionalObjectTag == InventoryManager.Instance.currentlyHeldObject.tag)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            InventoryManager.Instance.RemoveFromInventory();

            if (questId > 0)
            {
                ActManager.Instance.CompleteSubQuest(actId, questId);
            }

            GameSceneManager.Instance.ChangeName(sceneName);
            gameObject.GetComponent<EnableableObject>().Disable();

            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                    if (a.GetComponent<EnableableObject>() != null)
                    {
                        a.GetComponent<EnableableObject>().Enable();
                    }
                }
            }

            StartCoroutine(SwitchScene());
        }  
    }
}
