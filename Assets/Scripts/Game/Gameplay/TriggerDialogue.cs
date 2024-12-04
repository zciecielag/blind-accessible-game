using Unity.VisualScripting;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour, IGameDataManager
{
    public GameObject[] activateObjects;
    public bool isEnabled;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isEnabled)
        {
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                }
                isEnabled = false;
            }
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
