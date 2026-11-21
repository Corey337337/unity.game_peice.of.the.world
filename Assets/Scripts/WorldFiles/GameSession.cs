using UnityEngine;

public static class GameSession
{
    static WorldInfo current;
    static WorldSaveData data;

    public static WorldInfo CurrentWorld
    {
        get => current;
        set { current = value; data = null; }
    }

    public static WorldSaveData Data
    {
        get
        {
            if (data == null)
                data = current != null ? WorldStorage.LoadWorldData(current.id)
                                       : new WorldSaveData();
            return data;
        }
    }

    public static void Save()
    {
        if (current != null) WorldStorage.SaveWorldData(current.id, Data);
    }
}
