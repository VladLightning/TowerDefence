
using System.IO;
using DG.Tweening.Core;
using UnityEngine;

public static class Save
{
    private static readonly string _savePath = Application.persistentDataPath + "/Saves.json";
    private static SavesData _savesData;

    public static void SaveGame()
    {
        _savesData.SavedHeroIndex = 1;
        string json = JsonUtility.ToJson(_savesData);
        File.WriteAllText(_savePath, json);
    }

    public static void LoadGame()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            _savesData = JsonUtility.FromJson<SavesData>(json);
            Debug.Log(_savesData.SavedHeroIndex);
        }
    }
    
    public static void SaveHero(int index)
    {
        _savesData.SavedHeroIndex = index;
    }
}

public struct SavesData
{
    public int SavedHeroIndex;
}