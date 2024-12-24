using UnityEngine;

public class QuestGiverObject : MonoBehaviour
{
    public int actId;
    public int questId;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            gameObject.GetComponent<EnableableObject>().isEnabled = false;
        }
    }
}
