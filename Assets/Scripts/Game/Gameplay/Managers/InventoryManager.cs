using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameDataManager
{

    public static InventoryManager Instance 
    { 
        get; 
        private set; 
    }
    public GameObject currentlyHeldObject;
    public GameObject inventoryItem;
    public TextMeshProUGUI inventoryText;

    void Start()
    {
        Instance = this;
    }

    public void AddToInventory(GameObject objectToAdd)
    {
        this.currentlyHeldObject = objectToAdd;
        if (inventoryItem != null && inventoryText != null)
        {
            inventoryItem.GetComponent<Image>().sprite = currentlyHeldObject.GetComponent<SpriteRenderer>().sprite;
            inventoryText.text = objectToAdd.name;
        }
    }

    public void RemoveFromInventory()
    {
        Destroy(currentlyHeldObject);
        this.currentlyHeldObject = null;
        inventoryItem.GetComponent<Image>().sprite = null;
        inventoryText.text = "Brak";
    }

    public void ChangeItemContrast()
    {
        if (currentlyHeldObject != null)
        {
            if (currentlyHeldObject.GetComponent<ChangeImageContrast>() != null)
            {
                currentlyHeldObject.GetComponent<ChangeImageContrast>().ChangeContrast();
                inventoryItem.GetComponent<Image>().sprite = currentlyHeldObject.GetComponent<SpriteRenderer>().sprite;
            }
        } 
    }

    public void LoadData(GameData data)
    {
        this.currentlyHeldObject = data.currentlyHeldObject;

        if (currentlyHeldObject == null && data.currentlyHeldObjectTag != "")
        {
            this.currentlyHeldObject = GameObject.FindGameObjectWithTag(data.currentlyHeldObjectTag);
        }
        
        if (currentlyHeldObject != null)
        {
            if (currentlyHeldObject.GetComponent<ChangeImageContrast>() != null)
            {
                currentlyHeldObject.GetComponent<ChangeImageContrast>().ChangeContrast();
            }
            if (inventoryItem != null && inventoryText != null)
            {
                inventoryItem.GetComponent<Image>().sprite = currentlyHeldObject.GetComponent<SpriteRenderer>().sprite;
                inventoryText.text = currentlyHeldObject.name;
            }
        } 
    }

    public void ShowInventory()
    {
        if (currentlyHeldObject != null)
        {
            inventoryItem.GetComponent<Image>().sprite = currentlyHeldObject.GetComponent<SpriteRenderer>().sprite;
            inventoryText.text = currentlyHeldObject.name;
        }
    }

    public void SaveData(ref GameData data)
    {
        if (this.currentlyHeldObject != null)
        {
            data.currentlyHeldObject = this.currentlyHeldObject;
            data.currentlyHeldObjectTag = this.currentlyHeldObject.tag;
        } else
        {
            data.currentlyHeldObjectTag = "";
        }
        
    }
}
