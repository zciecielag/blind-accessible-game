using UnityEngine;

public class CheckIfCanBeEnabled : MonoBehaviour
{
    public static CheckIfCanBeEnabled Instance {get; private set;}
    public int actId;
    public int questId;
    public GameObject objectToEnable;
    
    void Start()
    {
        Instance = this;
    }

    public void Check()
    {
        if (ActManager.Instance.currentActId == actId && ActManager.Instance.currentQuestId == questId)
        {
            objectToEnable.SetActive(true);
        }
    }
}
