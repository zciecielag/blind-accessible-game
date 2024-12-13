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
            if (objectToEnable.activeSelf == true)
            {
                Debug.Log("deactivating" + objectToEnable.name);
                objectToEnable.SetActive(false);
            }
            Debug.Log("activating" + objectToEnable.name);
            if (objectToEnable.GetComponent<SwitchSceneOnCollide>() != null) { 
                objectToEnable.GetComponent<SwitchSceneOnCollide>().isEnabled = true; 
            }
            objectToEnable.SetActive(true);
        }
    }
}
