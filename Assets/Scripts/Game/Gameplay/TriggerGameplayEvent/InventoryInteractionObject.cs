using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{
    public int actId;
    public int questId;

    public GameObject objectBeingChanged;
    public Sprite unchangedSprite;
    public Sprite changedSprite;

    public GameObject[] activateObjects;
    public GameObject[] deactivateObjects;

    public GameObject confirmInteractionButton;

    public bool addOrUse;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
            confirmInteractionButton.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player" && gameObject.GetComponent<EnableableObject>().isEnabled)
        {
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
}
