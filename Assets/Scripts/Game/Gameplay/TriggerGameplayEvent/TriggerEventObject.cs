using UnityEngine;

public class TriggerEventObject : MonoBehaviour
{
    public int actId;
    public int questId;
    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
            ActManager.Instance.AcquireQuest(actId, questId);
            
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                    if (a.GetComponent<EnableableObject>() != null)
                    {
                        a.GetComponent<EnableableObject>().isEnabled = true;
                    }
                }
            }

            if (deactivateObjects != null)
            {
                foreach (GameObject a in deactivateObjects)
                {
                    a.SetActive(false);
                    if (a.GetComponent<EnableableObject>() != null)
                    {
                        a.GetComponent<EnableableObject>().isEnabled = false;
                    }
                }
            }

            gameObject.GetComponent<EnableableObject>().isEnabled = false;
            GameDataManager.Instance.SaveGame();

            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.SetActive(false);
        }
    }
}
