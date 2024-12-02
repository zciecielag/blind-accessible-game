using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class GameData
{

    //Tutaj bedziemy zapisywac praktycznie wszystkie potrzebne zmienne do progresji gry
    //Np. ostatnia pozycja gracza, stan ekwipunku, stan questow, ogolnie wszystko
    public string currentSceneName;
    public GameObject currentlyHeldObject;
    
    public int currentActId;
    public int currentSubQuestId;
    public GameData()
    {
        this.currentSceneName = "Cutscene.01.StartCutscene";
        this.currentlyHeldObject = null;
        this.currentActId = 0;
        this.currentSubQuestId = 1;
    }
}
