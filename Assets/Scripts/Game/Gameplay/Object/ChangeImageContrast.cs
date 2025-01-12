using UnityEngine;

public class ChangeImageContrast : MonoBehaviour
{
    public static ChangeImageContrast Instance;

    public Sprite contrastSprite;
    public Sprite noContrastSprite;
    public SpriteRenderer targetSpriteRenderer;

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();

    void Start()
    {
        ChangeContrast();
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeContrast()
    {
        if (targetSpriteRenderer != null)
        {
            if (globalVariableManager.GetContrastStatus())
            {
                targetSpriteRenderer.sprite = contrastSprite;
            }
            else
            {
                targetSpriteRenderer.sprite = noContrastSprite;
            }
        }
    }
}
