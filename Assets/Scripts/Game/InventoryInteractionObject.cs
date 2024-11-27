using System.Collections;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{

    public int questId;
    public GameObject doneText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //TODO - sprawdzanie czy gracz zrobił double tap gdziekolwiek i wtedy dodaje do ekwipunku
            InventoryManager.Instance.AddToInventory(gameObject);
            ActManager.Instance.CompleteSubQuest(questId);
            gameObject.SetActive(false);
            
            //Po deaktywacji obiektu nie mozna zaczac coroutine, wiec uzywamy kamery do czekania
            MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>();
            camMono.StartCoroutine(ShowDoneTextAndHide());
        }
    }
    
    private IEnumerator ShowDoneTextAndHide()
    {
        doneText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        doneText.SetActive(false);
    }
}
