using UnityEngine;

public class Quest
{
    public int id;
    public bool isActive;
    public bool isCompleted;

    public Quest(int id, bool isActive, bool isCompleted) {
        this.id = id;
        this.isActive = isActive;
        this.isCompleted = isCompleted;
    }
}
