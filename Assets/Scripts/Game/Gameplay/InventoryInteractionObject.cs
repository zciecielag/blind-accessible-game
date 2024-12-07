using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour, IGameDataManager
{
    public int actId;
    public int questId;
    public bool isEnabled;
    public GameObject doneText;

    public GameObject objectBeingChanged;
    public Sprite unchangedSprite;
    public Sprite changedSprite;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    public bool addOrUse;

    private float doubleTapTime = 0.6f;
    private int countTap = 0;
    private bool collisionActive = false;

    private void OnEnable()
    {
        isEnabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && isEnabled)
        {
            collisionActive = true;
            StartCoroutine(WaitForTap());
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" && isEnabled)
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
        gameObject.GetComponent<DontDestroyObject>().ActivateDontDestroy();

        isEnabled = false;
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

    private void UseInventoryObject()
    {
        InventoryManager.Instance.RemoveFromInventory();
        ActManager.Instance.CompleteSubQuest(questId);

        isEnabled = false;
        GameDataManager.Instance.SaveGame();

        gameObject.GetComponent<AudioSource>().Stop();

        if (changedSprite != null)
        {
            objectBeingChanged.GetComponent<SpriteRenderer>().sprite = changedSprite;
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

    public void LoadData(GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            this.isEnabled = data.enabledGameObjects[this.gameObject.tag];
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.enabledGameObjects.ContainsKey(this.gameObject.tag))
        {
            Debug.Log("Contains key");
            data.enabledGameObjects[this.gameObject.tag] = this.isEnabled;
        }
        else
        {
            Debug.Log("Creating new key");
            data.enabledGameObjects.Add(this.gameObject.tag, isEnabled);
        }
    }
}
