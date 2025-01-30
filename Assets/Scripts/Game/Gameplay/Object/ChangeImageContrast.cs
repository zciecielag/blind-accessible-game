using UnityEngine;

public class ChangeImageContrast : MonoBehaviour
{
    public static ChangeImageContrast Instance;

    public Sprite contrastSprite;
    public Sprite noContrastSprite;
    public SpriteRenderer targetSpriteRenderer;

    private GlobalVariableManager globalVariableManager = new GlobalVariableManager();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangeContrast()
    {
        if (targetSpriteRenderer != null && contrastSprite != null && noContrastSprite != null)
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

    public void ChangeToContrast()
    {
        if (targetSpriteRenderer != null && contrastSprite != null && noContrastSprite != null)
        {
            targetSpriteRenderer.sprite = contrastSprite;
        }
    }

    public void ChangeToNoContrast()
    {
        if (targetSpriteRenderer != null && contrastSprite != null && noContrastSprite != null)
        {
            targetSpriteRenderer.sprite = noContrastSprite;
        }
    }
}
