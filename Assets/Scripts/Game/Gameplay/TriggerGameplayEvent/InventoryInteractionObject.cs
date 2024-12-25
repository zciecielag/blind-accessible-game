using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{
    public int actId;
    public int questId;
    public GameObject doneText;

    public GameObject objectBeingChanged;
    public Sprite unchangedSprite;
    public Sprite changedSprite;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    public GameObject confirmInteractionButton;

    public bool addOrUse;

    private float doubleTapTime = 0.5f;
    private int countTap = 0;
    private bool collisionActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
            collisionActive = true;
            confirmInteractionButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
            collisionActive = false;
            confirmInteractionButton.SetActive(false);
        }
    }

    public void AddOrUse()
    {
        if (addOrUse)
        {
            AddToInventory();
        }
        else
        {
            UseInventoryObject();
        }
    }

    private void AddToInventory()
    {
        InventoryManager.Instance.AddToInventory(gameObject);
        ActManager.Instance.CompleteSubQuest(actId, questId);
        gameObject.GetComponent<DontDestroyObject>().ActivateDontDestroy();

        confirmInteractionButton.SetActive(false);

        gameObject.GetComponent<EnableableObject>().isEnabled = false;
        GameDataManager.Instance.SaveGame();

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
    }

    private void UseInventoryObject()
    {
        InventoryManager.Instance.RemoveFromInventory();
        ActManager.Instance.CompleteSubQuest(actId, questId);

        confirmInteractionButton.SetActive(false);

        gameObject.GetComponent<EnableableObject>().isEnabled = false;
        GameDataManager.Instance.SaveGame();

        gameObject.GetComponent<AudioSource>().Stop();

        if (objectBeingChanged != null && changedSprite != null)
        {
            objectBeingChanged.GetComponent<SpriteRenderer>().sprite = changedSprite;
            if (objectBeingChanged.GetComponent<ChangeSpriteOnLoad>() != null)
            {
                objectBeingChanged.GetComponent<ChangeSpriteOnLoad>().Change(changedSprite);
            }
        }

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
    IEnumerator WaitForTap()
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
                if (collisionActive) {StartCoroutine(WaitForTap());} else { collisionActive = false; }
            }
        }
        else
        {
            if (collisionActive) {StartCoroutine(WaitForTap());} else { collisionActive = false; }
        }
    }

    IEnumerator CheckDoubleTap()
    {
        yield return new WaitForSeconds(doubleTapTime);

        if (countTap == 1)
        {
            Debug.Log("Single");
            if (collisionActive) {StartCoroutine(WaitForTap());} else { collisionActive = false; }
        }
        else if (countTap == 2)
        {
            Debug.Log("Double");
            countTap = 0;
            if (collisionActive) 
            {
                if (addOrUse)
                {
                    AddToInventory();
                }
                else
                {
                    UseInventoryObject();
                }
            } else { collisionActive = false; }
        }
    }

    private IEnumerator ShowDoneTextAndHide()
    {
        if (doneText != null)
        {
            doneText.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            doneText.SetActive(false);
        }
    }
}
