using UnityEngine;

public class EnableableObject : MonoBehaviour, IGameDataManager
{
    public bool isEnabled;

    public bool GetEnabledStatus()
    {
        return isEnabled;
    }

    public void Enable()
    {
        isEnabled = true;
        if (gameObject.GetComponent<ChangeImageContrast>() != null)
        {
            var gvm = new GlobalVariableManager();
            if (gvm.GetContrastStatus())
            {
               gameObject.GetComponent<ChangeImageContrast>().ChangeToContrast(); 
            }
            else
            {
                gameObject.GetComponent<ChangeImageContrast>().ChangeToNoContrast(); 
            }
        }
    }

    public void Disable()
    {
        isEnabled = false;
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
