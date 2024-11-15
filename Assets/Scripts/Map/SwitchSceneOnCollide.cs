using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private AudioSource audioSource;

    private GameData gameData;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            StartCoroutine(waiting());
        }
    }

    IEnumerator waiting()
    {   
        audioSource.Play();
        yield return new WaitForSeconds(0.8f);
        gameData.currentSceneName = sceneToLoad;
        SceneManager.LoadScene(sceneName:sceneToLoad);
    }
}
