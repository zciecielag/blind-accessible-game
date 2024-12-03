using Unity.VisualScripting;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject[] activateObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                }
                gameObject.GetComponent<TriggerDialogue>().enabled = false;
            }
        }
    }
}
