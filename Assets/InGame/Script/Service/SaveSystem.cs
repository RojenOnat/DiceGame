using System.Collections;
using System.Collections.Generic;
using System.IO;
using Palmmedia.ReportGenerator.Core.Common;
using UnityEngine;

public class SaveSystem : IInitializable
{
    
    
    public void Initialize()
    {
        //Init
    }

    public void SaveData <T> (T objectToSave,string filePath)
    {
        string jsonString = JsonUtility.ToJson(objectToSave);
        
        File.WriteAllText(filePath,jsonString);
    }

    public T LoadData<T>(T objectToLoad,string path)
    {
    
        string jsonString = File.ReadAllText(path);
        objectToLoad = JsonUtility.FromJson<T>(jsonString);
        
        
        return objectToLoad;
    }

    public bool ExistingFileControl<T>(T controlingObject,string path)
    {
        if (File.Exists(path))
        {
            Debug.Log("Registered data found and loaded.");
            return true;
        }
       
        
        Debug.LogAssertion($"Saved data not found.Data has been generated automatically. {path}");
        return false;
    }
}
