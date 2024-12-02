using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{

    public int questId;
    public GameObject doneText;
    public bool canBeTaken;
    private float doubleTapTime = 0.6f;
    private int countTap;

    private bool collisionActive = false;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && canBeTaken)
        {
            collisionActive = true;
            StartCoroutine(waitForTap());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" && canBeTaken)
        {
            collisionActive = false;
            countTap = 0;
            StopAllCoroutines();
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
                if (collisionActive) {StartCoroutine(CheckDoubleTap());} else { collisionActive = false; }
            } 
            else 
            {
                if (collisionActive) {StartCoroutine(waitForTap());} else { collisionActive = false; }
            }
        }
        else
        {
            if (collisionActive) {StartCoroutine(waitForTap());} else { collisionActive = false; }
        }
    }

    IEnumerator CheckDoubleTap()
    {
        yield return new WaitForSeconds(doubleTapTime);

        if (countTap == 1)
        {
            Debug.Log("Single");
            if (collisionActive) {StartCoroutine(waitForTap());} else { collisionActive = false; }
        }
        else if (countTap == 2)
        {
            Debug.Log("Double");
            countTap = 0;
            if (collisionActive) {AddToInventory();} else { collisionActive = false; }
        }
    }

    private IEnumerator ShowDoneTextAndHide()
    {
        doneText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        doneText.SetActive(false);
    }

}
