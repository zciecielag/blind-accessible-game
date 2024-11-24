using UnityEngine;

public class FadeController : MonoBehaviour
{

    FadeInOut fadeInOut;
    void Start()
    {
        fadeInOut = FindObjectOfType<FadeInOut>();
        fadeInOut.FadeOut();
    }
}