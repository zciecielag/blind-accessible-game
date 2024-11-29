using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private AudioSource audioSource;

    private GameData gameData;
    FadeInOut fadeInOut;

    void Start()
    {
        fadeInOut = FindFirstObjectByType<FadeInOut>();
    }

    public IEnumerator SwitchScene()
    {
        fadeInOut.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName: sceneToLoad);

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            GameDataManager.Instance.SaveGame();
            StartCoroutine(SwitchScene());
            //StartCoroutine(waiting());
        }
    }

    //IEnumerator waiting()
    //{   
    //    audioSource.Play();
    //    yield return new WaitForSeconds(0.8f);
    //    gameData.currentSceneName = sceneToLoad;
    //    SceneManager.LoadScene(sceneName:sceneToLoad);
    //}
}
