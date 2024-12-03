using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour
{
    public string sceneToLoad;
    public AudioSource audioSource;
    FadeInOut fadeInOut;
    public bool canSwitch;
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
            if (canSwitch)
            {
                GameDataManager.Instance.SaveGame();
                StartCoroutine(SwitchScene());
                //StartCoroutine(waiting());
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

    private void blockEntrance()
    {

    }

    //IEnumerator waiting()
    //{   
    //    audioSource.Play();
    //    yield return new WaitForSeconds(0.8f);
    //    gameData.currentSceneName = sceneToLoad;
    //    SceneManager.LoadScene(sceneName:sceneToLoad);
    //}
}
