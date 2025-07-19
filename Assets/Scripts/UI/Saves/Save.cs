using System.IO;
using AYellowpaper.SerializedCollections;
using Newtonsoft.Json;
using UnityEngine;

public static class Save
{
    private static readonly string _savePath = Application.persistentDataPath + "/Saves.json";
    private static SavesData _savesData;
    
    public static void SaveHero(int index)
    {
        _savesData.SavedHeroIndex = index;
        SaveGame();
    }

    public static int GetSavedHeroIndex()
    {
        return _savesData.SavedHeroIndex;
    }

    public static void SaveCompletedLevelIndex(int index)
    {
        _savesData.SavedLatestCompletedLevelIndex = index;
        SaveGame();
    }

    public static int GetSavedLatestCompletedLevelIndex()
    {
        return _savesData.SavedLatestCompletedLevelIndex;
    }

    public static void SaveEnemiesDeathCounts(SerializedDictionary<EnemiesEnum, int> deathCounts)
    {
        _savesData.SavedDeathCounts = deathCounts;
        SaveGame();
    }

    public static SerializedDictionary<EnemiesEnum, int> GetSavedDeathCounts()
    {
        return _savesData.SavedDeathCounts;
    }
    
    private static void SaveGame()
    {
        string json = JsonConvert.SerializeObject(_savesData, Formatting.Indented);
        File.WriteAllText(_savePath, json);
    }

    public static void LoadGame()
    {
        if (File.Exists(_savePath))
        {
            string json = File.ReadAllText(_savePath);
            _savesData = JsonConvert.DeserializeObject<SavesData>(json);
        }
    }
    
    private struct SavesData
    {
        public int SavedHeroIndex;

        public int SavedLatestCompletedLevelIndex;
        
        public SerializedDictionary<EnemiesEnum, int> SavedDeathCounts;
    }
}
