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
                if (objectToDisable.GetComponent<EnableableObject>() != null) { 
                    objectToDisable.GetComponent<EnableableObject>().isEnabled = false;
                    if(objectToEnable.GetComponent<SpriteRenderer>() != null) { objectToEnable.GetComponent<SpriteRenderer>()
                    .sortingLayerID = SortingLayer.NameToID("Default"); }
                }
                
                objectToDisable.SetActive(false);
            }

            if (objectToEnable.activeSelf == true)
            {
                objectToEnable.SetActive(false);
            }

            if (objectToEnable.GetComponent<EnableableObject>() != null) { 
                objectToEnable.GetComponent<EnableableObject>().isEnabled = true;
                if(objectToEnable.GetComponent<SpriteRenderer>() != null) { objectToEnable.GetComponent<SpriteRenderer>()
                    .sortingLayerID = SortingLayer.NameToID("Foreground"); }
            }

            objectToEnable.SetActive(true);
        }
    }
}
