using UnityEngine;

public class InventoryInteractionObject : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //TODO - sprawdzanie czy gracz zrobił double tap gdziekolwiek i wtedy dodaje do ekwipunku
            InventoryManager.Instance.AddToInventory(gameObject);
        }
    }
}
