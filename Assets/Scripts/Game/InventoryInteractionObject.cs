using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{

    public int questId;
    public GameObject doneText;
    public bool canBeTaken;
    private float doubleTapTime = 0.6f;
    private int countTap;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entered inventory object collision");
        if (other.tag == "Player" && canBeTaken)
        {
            StartCoroutine(waitForTap());
        }
    }

    private void AddToInventory()
    {
        InventoryManager.Instance.AddToInventory(gameObject);
        ActManager.Instance.CompleteSubQuest(questId);
        gameObject.GetComponent<DontDestroyInventory>().ActivateDontDestroy();
        canBeTaken = false;
        gameObject.GetComponent<AudioSource>().Stop();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        
        //Po deaktywacji obiektu nie mozna zaczac coroutine, wiec uzywamy kamery do czekania
        MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>();
        camMono.StartCoroutine(ShowDoneTextAndHide());

        if (activateObjects != null)
        {
            foreach (GameObject a in activateObjects)
            {
                a.SetActive(true);
            }
        }

        if (deactivateObjects != null)
        {
            foreach (GameObject a in deactivateObjects)
            {
                a.SetActive(false);
            }
        }
    }
    
    //Tapy sie nie rejestruja caly czas
    IEnumerator waitForTap()
    {
        yield return new WaitForEndOfFrame();
        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                countTap++;
                StartCoroutine(CheckDoubleTap());
            } 
            else 
            {
                StartCoroutine(waitForTap());
            }
        }
        else
        {
            StartCoroutine(waitForTap());
        }
    }

    IEnumerator CheckDoubleTap()
    {
        yield return new WaitForSeconds(doubleTapTime);

        if (countTap == 1)
        {
            Debug.Log("SingleTap");
            StartCoroutine(waitForTap());
        }
        else if (countTap == 2)
        {
            Debug.Log("DoubleTap");
            countTap = 0;
            AddToInventory();
        }
    }

    private IEnumerator ShowDoneTextAndHide()
    {
        doneText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        doneText.SetActive(false);
    }

}
