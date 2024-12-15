using Unity.VisualScripting;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
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
        }
    }

}
