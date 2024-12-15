using UnityEngine;

public class EnableableObject : MonoBehaviour, IGameDataManager
{
    public bool isEnabled;

    public void LoadData(GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            this.isEnabled = data.enabledGameObjects[this.gameObject.tag];
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            Debug.Log("Contains key");
            data.enabledGameObjects[this.gameObject.tag] = this.isEnabled;
        }
        else
        {
            Debug.Log("Creating new key");
            data.enabledGameObjects.Add(this.gameObject.tag, isEnabled);
        }
    }
}
