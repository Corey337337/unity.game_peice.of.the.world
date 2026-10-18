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

}
