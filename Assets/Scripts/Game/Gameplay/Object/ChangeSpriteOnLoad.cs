using UnityEngine;

public class ChangeSpriteOnLoad : MonoBehaviour, IGameDataManager
{
    public Sprite unchangedSprite;
    public Sprite changedSprite;
    public Sprite changedSpriteContrast;
    public bool isChanged;

    GlobalVariableManager gvm = new GlobalVariableManager();

    private void Start()
    {
        if (isChanged)
        {
            if (gvm.GetContrastStatus())
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = changedSpriteContrast;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = changedSprite;
            }
        }
    }

    public void Change(Sprite spriteToChange)
    {
        if (gvm.GetContrastStatus())
        {
            this.changedSprite = changedSpriteContrast;
        }
        else
        {
            this.changedSprite = spriteToChange;
        }
        isChanged = true;
    }

    public void LoadData(GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            this.isChanged = data.enabledGameObjects[this.gameObject.tag];
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            Debug.Log("Contains key");
            data.enabledGameObjects[this.gameObject.tag] = this.isChanged;
        }
        else
        {
            Debug.Log("Creating new key");
            data.enabledGameObjects.Add(this.gameObject.tag, isChanged);
        }
    }
}
