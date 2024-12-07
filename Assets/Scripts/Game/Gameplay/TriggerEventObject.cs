using UnityEngine;

public class TriggerEventObject : MonoBehaviour, IGameDataManager
{
    public int actId;
    public int questId;
    public bool isEnabled;
    public GameObject[] activateObjects;

    private void OnEnable()
    {
        isEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && isEnabled)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                }
            }

            isEnabled = false;
            GameDataManager.Instance.SaveGame();

            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.SetActive(false);
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
