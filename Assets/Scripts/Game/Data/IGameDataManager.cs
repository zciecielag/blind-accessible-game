using UnityEngine;

public interface IGameDataManager
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
