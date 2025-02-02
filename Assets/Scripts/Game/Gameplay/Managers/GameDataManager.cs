using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Unity.VisualScripting;

public class GameDataManager : MonoBehaviour
{
    public string fileName;
    private GameData gameData;
    private FileDataManager fileDataManager;
    private List<IGameDataManager> gameDataManagers;
    public static GameDataManager Instance 
    { 
        get; 
        private set; 
    }
    private CheckIfCanBeEnabled[] checkIfCanBeEnableds;

    private void Awake()
    {
        this.gameDataManagers = FindGameDataManagers();
        Instance = this;
    }

    private void Start() 
    {
        this.fileDataManager = new FileDataManager(Application.persistentDataPath, fileName);
        LoadGame();
        checkIfCanBeEnableds = FindObjectsByType<CheckIfCanBeEnabled>(FindObjectsSortMode.None);
    }

    public void NewGame()
    {
        gameData = new GameData();
        fileDataManager.Save(gameData);
    }

    public void LoadGame()
    {
        this.gameData = fileDataManager.Load();
        this.gameDataManagers = FindGameDataManagers();

        if (this.gameData == null) 
        {
            Debug.Log("No game data found. Creating new default data.");
            NewGame();
        }

        foreach(IGameDataManager gameDataManager in gameDataManagers)
        {
            gameDataManager.LoadData(gameData);
        }

        if (checkIfCanBeEnableds != null)
        {
            foreach (CheckIfCanBeEnabled a in checkIfCanBeEnableds)
            {
                a.Check();
            }
        }
    }

    public void SaveGame()
    {
        this.gameDataManagers = FindGameDataManagers();

        if (this.gameData == null)
        {
            LoadGame();
        }

        foreach(IGameDataManager gameDataManager in gameDataManagers)
        {
            gameDataManager.SaveData(ref gameData);
        }

        fileDataManager.Save(gameData);
        Debug.Log("Game was saved");
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
