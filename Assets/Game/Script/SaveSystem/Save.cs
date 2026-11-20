using UnityEngine;

public static class Save
{
    private const string SaveKey = "PlayerPrefs";

    public static void SaveGame(SaveData data)
    {
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(SaveKey, json);
        PlayerPrefs.Save();
    }

    public static SaveData LoadGame()
    {
        if (!PlayerPrefs.HasKey(SaveKey))
            return CreateDefaultData();

        string json = PlayerPrefs.GetString(SaveKey);

        return JsonUtility.FromJson<SaveData>(json);
    }

    public static SaveData CreateDefaultData()
    {
        return new SaveData
        {
            RockAmount = 0,
            OreAmount = 0,
            PurchasedPick = new bool[4],
            PurchasedPickCount = 0,
        };
    }
}