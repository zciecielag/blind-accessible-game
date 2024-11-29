using UnityEngine;

public class DontDestroyInventory : MonoBehaviour
{

    private void Awake()
    {
        GameObject[] invObject = GameObject.FindGameObjectsWithTag(this.gameObject.tag);
         if (invObject.Length > 1)
        {
            Debug.Log("Too many game objects");
            Destroy(this.gameObject);
        }
    }

    public void ActivateDontDestroy()
    {
        Debug.Log("Dont destroy inventory");
        DontDestroyOnLoad(this.gameObject);
    }
}
