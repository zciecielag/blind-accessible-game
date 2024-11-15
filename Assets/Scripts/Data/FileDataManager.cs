using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class FileDataManager
{
    private string directoryPath = "";
    private string fileName = "";

    public FileDataManager(string directoryPath, string fileName)
    {
        this.directoryPath = directoryPath;
        this.fileName = fileName;
    }

    public GameData Load()
    {
        string path = Path.Combine(directoryPath, fileName);
        GameData data = null;
        if (File.Exists(path))
        {
            try
            {
                string jsonData = "";
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        jsonData = streamReader.ReadToEnd();
                    }
                }

                data = JsonUtility.FromJson<GameData>(jsonData);

            } catch (Exception e)
            {
                Debug.LogError("An error occured while loading data from file.");
                Debug.LogException(e);
            }
        }

        return data;
    }

    public void Save(GameData data)
    {
        string path = Path.Combine(directoryPath, fileName);
        try 
        {
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            string jsonData = JsonUtility.ToJson(data, true);

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.Write(jsonData);
                }
            }

        } catch (Exception e)
        {
            Debug.LogError("An error occured while saving the game");
            Debug.LogException(e);
        }
    }
}
