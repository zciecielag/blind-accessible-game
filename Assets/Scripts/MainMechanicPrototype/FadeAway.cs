using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAway : MonoBehaviour
{
    public float fadeD = 2f;
    private CanvasGroup canvasG;

    void Start()
    {
        canvasG = gameObject.AddComponent<CanvasGroup>();
    }

    public void StartFade()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        float startAlpha = canvasG.alpha;

        while (elapsedTime < fadeD)
        {
            elapsedTime += Time.deltaTime;
            canvasG.alpha = Mathf.Lerp(startAlpha, 0f, elapsedTime / fadeD);
            yield return null;
        }
        canvasG.alpha = 0f;
        gameObject.SetActive(false);
    }
}
