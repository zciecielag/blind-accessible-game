using UnityEngine;

public class FadeController : MonoBehaviour
{

    FadeInOut fadeInOut;
    void Start()
    {
        fadeInOut = FindFirstObjectByType<FadeInOut>();
        fadeInOut.FadeOut();
    }
}