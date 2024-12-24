using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SwitchSceneOnEnable : MonoBehaviour
{
    public int actId;
    public int questId;
    public string scene;
    public AudioSource audioSource;
    FadeInOut fadeInOut;

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
        GameSceneManager.Instance.ChangeName(scene);
        GameDataManager.Instance.SaveGame();
        SceneManager.LoadScene(scene);

    }

    private void OnEnable()
    {
        ActManager.Instance.AcquireQuest(actId, questId);
        StartCoroutine(SwitchScene());
    }
}
