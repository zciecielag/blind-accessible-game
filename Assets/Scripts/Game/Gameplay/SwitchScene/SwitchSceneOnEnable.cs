using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchSceneOnEnable : MonoBehaviour
{
    public int actId;
    public int questId;
    public string scene;
    public AudioSource audioSource;
    private FadeInOut fadeInOut;

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
        if (audioSource != null)
        {
            audioSource.Play();
        }
        yield return new WaitForSeconds(1);

        if (GameSceneManager.Instance != null)
        {
            GameSceneManager.Instance.ChangeName(scene);
        }
        if (GameDataManager.Instance != null)
        {
            GameDataManager.Instance.SaveGame();
        }
        SceneManager.LoadScene(scene);
    }

    private void OnEnable()
    {
        if (ActManager.Instance != null)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
        }
        StartCoroutine(SwitchScene());
    }
}
