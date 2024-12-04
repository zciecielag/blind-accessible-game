using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class GameData
{
    public string currentSceneName;
    public GameObject currentlyHeldObject;
    public int currentActId;
    public int currentSubQuestId;
    public SerializableDictionary<string, bool> enabledGameObjects;
    public GameData()
    {
        this.currentSceneName = "Cutscene.01.StartCutscene";
        this.currentlyHeldObject = null;
        this.currentActId = 0;
        this.currentSubQuestId = 1;
        this.enabledGameObjects = new SerializableDictionary<string, bool>();
    }
}
