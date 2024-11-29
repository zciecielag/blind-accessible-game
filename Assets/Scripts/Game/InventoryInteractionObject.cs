using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{

    public int questId;
    public GameObject doneText;

    public Boolean canBeTaken;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && canBeTaken)
        {
            //TODO - sprawdzanie czy gracz zrobił double tap gdziekolwiek i wtedy dodaje do ekwipunku
            InventoryManager.Instance.AddToInventory(gameObject);
            ActManager.Instance.CompleteSubQuest(questId);
            gameObject.GetComponent<DontDestroyInventory>().ActivateDontDestroy();
            canBeTaken = false;
            gameObject.GetComponent<AudioSource>().Stop();
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            
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
