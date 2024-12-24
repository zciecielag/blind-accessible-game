using System.Collections.Generic;
using UnityEngine;

public class Act : Quest
{
    public int currentQuestIndex;
    public List<SubQuest> quests;

    public Act(int id, bool isActive, bool isCompleted, int currentQuestIndex, List<SubQuest> quests) : base(id, isActive, isCompleted)
    {
        this.currentQuestIndex = currentQuestIndex;
        this.quests = quests;
    }
}
