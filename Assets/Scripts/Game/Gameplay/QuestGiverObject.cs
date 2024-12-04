using UnityEngine;

public class QuestGiverObject : MonoBehaviour, IGameDataManager
{
    public int actId;
    public int questId;
    public bool isEnabled;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isEnabled)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            isEnabled = false;
        }
    }

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
            data.enabledGameObjects[this.gameObject.tag] = this.isEnabled;
        }
        else
        {
            data.enabledGameObjects.Add(this.gameObject.tag, isEnabled);
        }
    }
}
