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
    //public Vector2 playerPostion;
    public GameData()
    {
        this.currentSceneName = "Scene.01.01.Hall";
        
    }
}
