using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActManager : MonoBehaviour, IGameDataManager
{
    public static ActManager Instance { get; private set; }
    public List<Act> allActs;

    //public Act currentAct;
    //public List<SubQuest> currentSubQuests;
    //public SubQuest currentSubQuest;
    //public int currentActIndex;
    //public int currentSubQuestIndex;

    public TextMeshProUGUI questTextDescription;

    public void LoadData(GameData data)
    {
        this.allActs = data.actProgress;
    }

    public void SaveData(ref GameData data)
    {
        data.actProgress = this.allActs;
    }

    void Start()
    {
        Instance = this;
    }

    //przechodzimy po wszystkich aktach i ich questach i zmieniamy potrzebne wartosci
    //TODO: usprawnic, brzydki for
    public void AcquireQuest(int questId)
    {
        for (int i = 0; i < allActs.Count; i++)
        {
            if (allActs[i].isActive)
            {
                var subquests = allActs[i].quests;
                for (int j = 0; j < subquests.Count; j++)
                {
                    if (subquests[j].id == questId)
                    {
                        subquests[j].isActive = true;
                        questTextDescription.text = subquests[j].description;
                        Debug.Log(subquests[j].description);
                        break;
                    }
                }
            }
        }
    }

    //przechodzimy po wszystkich aktach i ich questach i zmieniamy potrzebne wartosci
    //TODO: usprawnic, brzydki for
    public void CompleteSubQuest(int questId)
    {
        for (int i = 0; i < allActs.Count; i++) {
            
            if (allActs[i].isActive)
            {
                var subquests = allActs[i].quests;
                var act = allActs[i];
                for (int j = 0; j < subquests.Count; j++)
                {
                    if (subquests[j].id == questId)
                    {
                        var quest = subquests[j];
                        quest.isActive = false;
                        quest.isCompleted = true;
                        subquests[j] = quest;
                        
                        Debug.Log("Subquest completed!");

                        if (j+1 <= subquests.Count - 1)
                        {
                            subquests[j+1].isActive = true;
                            questTextDescription.text = subquests[j+1].description;
                            //currentSubQuest = currentSubQuests[j+1];
                        }
                        else
                        {
                            act.isActive = false;
                            act.isCompleted = true;
                            allActs[i] = act;

                            Debug.Log("Act completed!");

                            if (i + 1 <= allActs.Count - 1)
                            {
                                //currentAct = allActs[i+1];
                            }
                        }
                        break;
                    }
                }
            }
        }
    }

}
