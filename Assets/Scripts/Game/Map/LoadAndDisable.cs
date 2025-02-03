using UnityEngine;

public class LoadAndDisable : MonoBehaviour
{
    private bool canEnable;
    void Start()
    {
        canEnable = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (this.gameObject.CompareTag(GameDataManager.Instance.GetGameData().playerSpawnPointTag) && canEnable)
        {
            GameDataManager.Instance.LoadGame();
            canEnable = false;
        }
    }
}
