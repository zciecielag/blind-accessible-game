using UnityEngine;
using UnityEngine.UI;

public class WhichRoomButtonBehaviour : MonoBehaviour, IGameDataManager
{
    public GameObject[] activateObjects;
    public bool isEnabled;
    private void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayRoomReminder);
        isEnabled = true;
    }

    private void Start()
    {
        if (isEnabled)
        {   
            gameObject.GetComponent<Button>().onClick.AddListener(PlayRoomReminder);
        }
    }
    private void PlayRoomReminder()
    {
        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
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
