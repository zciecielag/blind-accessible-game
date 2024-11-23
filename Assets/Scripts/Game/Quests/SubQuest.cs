using UnityEngine;

public class SubQuest : Quest
{
    public int actId;
    public string description;
    public SubQuest(int id, bool isActive, bool isCompleted, int actId, string description) : base(id, isActive, isCompleted)
    {
        this.actId = actId;
        this.description = description;
    }
}
