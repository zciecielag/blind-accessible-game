using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour, IGameDataManager
{

    public static InventoryManager Instance { get; private set; }
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
        inventoryItem.GetComponent<Image>().sprite = currentlyHeldObject.GetComponent<SpriteRenderer>().sprite;
        inventoryText.text = objectToAdd.name;
    }

    public void LoadData(GameData data)
    {
        this.currentlyHeldObject = data.currentlyHeldObject;
    }

    public void SaveData(ref GameData data)
    {
        data.currentlyHeldObject = this.currentlyHeldObject;
    }
}
