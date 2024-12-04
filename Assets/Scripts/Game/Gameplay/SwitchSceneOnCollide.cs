using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour, IGameDataManager
{
    public string sceneToLoad;
    public AudioSource audioSource;
    FadeInOut fadeInOut;
    public bool isEnabled;
    public GameObject[] activateObjects;

    void Start()
    {
        fadeInOut = FindFirstObjectByType<FadeInOut>();
    }

    public IEnumerator SwitchScene()
    {
        fadeInOut.FadeIn();
        audioSource.Play();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName: sceneToLoad);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player")
        {
            if (isEnabled)
            {
                GameDataManager.Instance.SaveGame();
                StartCoroutine(SwitchScene());
            }
            else
            {
                if (activateObjects != null)
                {
                    foreach (GameObject a in activateObjects)
                    {
                        a.SetActive(true);
                    }
                }
            }
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
