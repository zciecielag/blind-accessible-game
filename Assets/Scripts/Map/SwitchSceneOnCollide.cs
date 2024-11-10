using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnCollide : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            StartCoroutine(waiting());
        }
    }

    IEnumerator waiting()
    {   
        audioSource.Play();
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(sceneName:sceneToLoad);
    }
}
