using UnityEngine;

public class QuestGiverObject : MonoBehaviour
{
    public bool canGive;
    public int actId;
    public int questId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && canGive)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            //trigger dialogue
            canGive = false;
        }
    }
}
