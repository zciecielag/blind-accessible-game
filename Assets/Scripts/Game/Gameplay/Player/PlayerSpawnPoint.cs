using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour, IGameDataManager
{
    public string spawnPointTag;
    public GameObject player;

    public static PlayerSpawnPoint Instance 
    {
        get;
        private set;
    }

    public void LoadData(GameData data)
    {
        this.spawnPointTag = data.playerSpawnPointTag;
        if (GameObject.FindGameObjectWithTag(spawnPointTag) != null)
        {
            player.transform.position = GameObject.FindGameObjectWithTag(spawnPointTag).transform.position;
        }
    }

    public void SaveData(ref GameData data)
    {
        data.playerSpawnPointTag = this.spawnPointTag;
    }

    public void ChangeSpawnPoint(string tag)
    {
        this.spawnPointTag = tag;
    }

    void Start()
    {
        Instance = this;
        if (spawnPointTag != null && player != null)
        {
            if (GameObject.FindGameObjectWithTag(spawnPointTag) != null)
            {
                player.transform.position = GameObject.FindGameObjectWithTag(spawnPointTag).transform.position;
            }
        }
    }
}
