using UnityEngine;

public class CheckIfContrast : MonoBehaviour
{
   public void ChangeToContrast()
   {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
   }

   public void ChangeToNoContrast()
   {
    this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
   }
}
