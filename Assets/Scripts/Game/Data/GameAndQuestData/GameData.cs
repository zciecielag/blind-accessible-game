using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class GameData
{
    public string currentSceneName;
    public string playerSpawnPointTag;
    public GameObject currentlyHeldObject;
    public string currentlyHeldObjectTag;
    public int currentActId;
    public int currentSubQuestId;
    public SerializableDictionary<string, bool> enabledGameObjects;
    public GameData()
    {
        this.currentSceneName = "Cutscene.01.StartCutscene";
        this.currentlyHeldObject = null;
        this.currentlyHeldObjectTag = "";
        this.currentActId = 0;
        this.currentSubQuestId = 1;
        this.enabledGameObjects = new SerializableDictionary<string, bool>();
    }
}
