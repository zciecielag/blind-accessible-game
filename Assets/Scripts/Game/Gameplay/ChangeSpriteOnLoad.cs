using UnityEngine;

public class ChangeSpriteOnLoad : MonoBehaviour, IGameDataManager
{
    public Sprite unchangedSprite;
    public Sprite changedSprite;
    public bool isChanged;

    private void Start()
    {
        if (isChanged)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = changedSprite;
        }
    }

    public void Change(Sprite spriteToChange)
    {
        this.changedSprite = spriteToChange;
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
