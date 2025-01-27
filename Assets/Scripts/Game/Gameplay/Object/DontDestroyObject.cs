using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{

    public void ActivateDontDestroy()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
