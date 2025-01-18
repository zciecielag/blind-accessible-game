using UnityEngine;

public class CheckIfCanAddObjToInventory : MonoBehaviour
{
    public static CheckIfCanAddObjToInventory Instance 
    {
        get; 
        private set;
    }
    public int actId;
    public int questId;
    public GameObject objectToAdd;
    
    void Start()
    {
        Instance = this;
    }

    public void Check()
    {
        if (ActManager.Instance.currentActId == actId && ActManager.Instance.currentQuestId == questId)
        {
            if (objectToAdd != null)
            {
                InventoryManager.Instance.AddToInventory(objectToAdd);
                GameDataManager.Instance.SaveGame();
            }
        }
    }
}
