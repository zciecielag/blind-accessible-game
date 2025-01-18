using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite brokenHeart;

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = brokenHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }
}
