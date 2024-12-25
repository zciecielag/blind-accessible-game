using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ActManager : MonoBehaviour, IGameDataManager
{
    public static ActManager Instance { get; private set; }
    public List<Act> allActs;
    public int currentActId = 0;
    public int currentQuestId = 0;

    public TextMeshProUGUI questTextDescription;

    public void LoadData(GameData data)
    {
        this.currentActId = data.currentActId;
        this.currentQuestId = data.currentSubQuestId;
        this.allActs = QuestData.allActs;
        AcquireQuest(this.currentActId, this.currentQuestId);
    }

    public void SaveData(ref GameData data)
    {
       data.currentActId = this.currentActId;
       data.currentSubQuestId = this.currentQuestId;
    }

    void Start()
    {
        Instance = this;
    }

    //przechodzimy po wszystkich aktach i ich questach i zmieniamy potrzebne wartosci
    //TODO: usprawnic, brzydki for
    public void AcquireQuest(int actId, int questId)
    {
        for (int i = 0; i < allActs.Count; i++)
        {
            if (actId == allActs[i].id)
            {
                allActs[i].isActive = true;
                this.currentActId = actId;
                var subquests = allActs[i].quests;
                for (int j = 0; j < subquests.Count; j++)
                {
                    if (subquests[j].id == questId)
                    {
                        subquests[j].isActive = true;
                        this.currentQuestId = questId;

                        if (questTextDescription != null) 
                        { 
                            questTextDescription.text = subquests[j].description;
                        }
                        
                        break;
                    }
                }
            }
        }
    }

    //przechodzimy po wszystkich aktach i ich questach i zmieniamy potrzebne wartosci
    //TODO: usprawnic, brzydki for
    public void CompleteSubQuest(int actId, int questId)
    {
        for (int i = 0; i < allActs.Count; i++) {
            
            if (actId == allActs[i].id)
            {
                allActs[i].isActive = true;
                this.currentActId = actId;
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
                            AcquireQuest(i, questId+1);
                            break;
                        }
                        else
                        {
                            act.isActive = false;
                            act.isCompleted = true;
                            allActs[i] = act;

                            Debug.Log("Act completed!");

                            if (i + 1 <= allActs.Count - 1)
                            {
                                AcquireQuest(actId+1, 1);
                                break;

                            }
                            else
                            {
                                Debug.Log("No more acts!");
                            }
                        }
                        break;
                    }
                }
            }
        }
    }

}
