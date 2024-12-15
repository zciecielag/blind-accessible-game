using UnityEngine;
using UnityEngine.UI;

public class WhichRoomButtonBehaviour : MonoBehaviour
{
    public GameObject[] activateObjects;
    private void OnEnable()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayRoomReminder);
        gameObject.GetComponent<EnableableObject>().isEnabled = true;
    }

    private void Start()
    {
        if (gameObject.GetComponent<EnableableObject>().isEnabled)
        {   
            gameObject.GetComponent<Button>().onClick.AddListener(PlayRoomReminder);
        }
    }
    private void PlayRoomReminder()
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
    }
}
