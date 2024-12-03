using UnityEngine;
using UnityEngine.UI;

public class WhichRoomButtonBehaviour : MonoBehaviour
{

    public GameObject[] activateObjects;
    private void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(PlayRoomReminder);
    }
    private void PlayRoomReminder()
    {
        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
            }
        }
    }
}
