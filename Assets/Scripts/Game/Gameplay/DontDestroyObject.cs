using UnityEngine;

public class DontDestroyObject : MonoBehaviour
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
        Debug.Log("Dont destroy");
        DontDestroyOnLoad(this.gameObject);
    }
}