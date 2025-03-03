using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour
{
    public string sceneToLoad;
    public AudioSource audioSource;
    FadeInOut fadeInOut;
    public GameObject[] activateObjects;
    public string spawnPointTag;
    public bool disableOnUse;

    private void Start()
    {
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
        if (disableOnUse)
        {
            this.gameObject.GetComponent<EnableableObject>().Disable();
        }
        GameSceneManager.Instance.ChangeName(sceneToLoad);
        PlayerSpawnPoint.Instance.ChangeSpawnPoint(spawnPointTag);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(sceneToLoad);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.tag == "Player")
        {
            if (gameObject.GetComponent<EnableableObject>().GetEnabledStatus())
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
                        if (a.GetComponent<EnableableObject>() != null)
                        {
                            a.GetComponent<EnableableObject>().Enable();
                        }
                    }
                }
            }
        }
    }
}
