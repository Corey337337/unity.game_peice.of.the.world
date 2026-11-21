using System.IO;
using UnityEngine;

public static class WorldStorage
{
    static string ListPath => Path.Combine(Application.persistentDataPath, "potw_worlds.json");
    static string WorldsDir => Path.Combine(Application.persistentDataPath, "potw_worlds");


    public static WorldList LoadList()
    {
        if (!File.Exists(ListPath))
        {
            return new WorldList();
        }
        return JsonUtility.FromJson<WorldList>(File.ReadAllText(ListPath));
    }

    public static void SaveList(WorldList list)
    {
        File.WriteAllText(ListPath, JsonUtility.ToJson(list, true));
    }

    public static void DeleteWorldData(string worldId)
    {
        string path = Path.Combine(WorldsDir, worldId + ".json");

        if (File.Exists(path))
        {
            File.Delete(path);
        }

    }

    static string WorldDataPath(string worldId) => Path.Combine(WorldsDir, worldId + ".json");

    public static WorldSaveData LoadWorldData(string worldId)
    {
        string path = WorldDataPath(worldId);
        if (!File.Exists(path)) return new WorldSaveData(); 
        return JsonUtility.FromJson<WorldSaveData>(File.ReadAllText(path));
    }

    public static void SaveWorldData(string worldId, WorldSaveData data)
    {
        Directory.CreateDirectory(WorldsDir);
        File.WriteAllText(WorldDataPath(worldId), JsonUtility.ToJson(data, true));
    }
}
