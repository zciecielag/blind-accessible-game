using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class GameDataManager : MonoBehaviour
{
    [SerializeField] private string fileName;

    private GameData gameData;
    private FileDataManager fileDataManager;
    private List<IGameDataManager> gameDataManagers;
    public static GameDataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one GDM instance");
        }
        this.gameDataManagers = FindGameDataManagers();
        Instance = this;
    }

    private void Start() 
    {
        this.fileDataManager = new FileDataManager(Application.persistentDataPath, fileName);
        this.gameDataManagers = FindGameDataManagers();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = fileDataManager.Load();

        if (this.gameData == null) 
        {
            Debug.Log("No game data found. Creating default data.");
            NewGame();
        }

        foreach(IGameDataManager gameDataManager in gameDataManagers)
        {
            gameDataManager.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(IGameDataManager gameDataManager in gameDataManagers)
        {
            gameDataManager.SaveData(ref gameData);
        }

        fileDataManager.Save(gameData);
        Debug.Log("Saved");
    }

    public GameData GetGameData()
    {
        return gameData;
    }

    private List<IGameDataManager> FindGameDataManagers() 
    {
        IEnumerable<IGameDataManager> gameDataManagers = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IGameDataManager>();
        
        return new List<IGameDataManager>(gameDataManagers);
    }
}
