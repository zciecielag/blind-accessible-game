using Unity.VisualScripting;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().GetEnabledStatus())
        {
            if (activateObjects != null)
            {
                foreach (GameObject a in activateObjects)
                {
                    a.SetActive(true);
                    if (a.GetComponent<EnableableObject>() != null)
                    {
                        a.GetComponent<EnableableObject>().Enable();
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
                        a.GetComponent<EnableableObject>().Disable();
                    }
                }
            }
            gameObject.GetComponent<EnableableObject>().Disable();
        }
    }

}
