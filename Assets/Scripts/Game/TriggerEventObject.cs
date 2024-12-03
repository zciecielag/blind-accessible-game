using UnityEngine;

public class TriggerEventObject : MonoBehaviour
{
    public bool canInteract;
    public int actId;
    public int questId;
    public GameObject[] activateObjects;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && canInteract)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                }
            }
            canInteract = false;
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
