using UnityEngine;

public class CheckIfCanBeEnabled : MonoBehaviour
{
    public static CheckIfCanBeEnabled Instance {get; private set;}
    public int actId;
    public int questId;
    public GameObject objectToEnable;
    public GameObject objectToDisable;
    
    void Start()
    {
        Instance = this;
    }

    public void Check()
    {
        if (ActManager.Instance.currentActId == actId && ActManager.Instance.currentQuestId == questId)
        {
            if (objectToDisable != null)
            {
                if (objectToDisable.GetComponent<SwitchSceneOnCollide>() != null) { 
                    objectToDisable.GetComponent<SwitchSceneOnCollide>().isEnabled = false; 
                }
                if (objectToDisable.GetComponent<SwitchSceneCompleteQuestWithCondition>() != null) { 
                    objectToDisable.GetComponent<SwitchSceneCompleteQuestWithCondition>().isEnabled = false; 
                }
                
                objectToDisable.SetActive(false);
            }

            if (objectToEnable.activeSelf == true)
            {
                objectToEnable.SetActive(false);
            }

            if (objectToEnable.GetComponent<SwitchSceneOnCollide>() != null) { 
                objectToEnable.GetComponent<SwitchSceneOnCollide>().isEnabled = true; 
            }
            if (objectToEnable.GetComponent<SwitchSceneCompleteQuestWithCondition>() != null) { 
                objectToEnable.GetComponent<SwitchSceneCompleteQuestWithCondition>().isEnabled = true; 
            }

            objectToEnable.SetActive(true);
        }
    }
}
