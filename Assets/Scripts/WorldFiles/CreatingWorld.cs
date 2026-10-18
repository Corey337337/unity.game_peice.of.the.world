using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CreatingWorld : MonoBehaviour
{
    public InputField inputField;
    public ScrollRect scrollRect;
    public WorldCard worldCardPrefab;

    private WorldList list;

    //private string userText;
    //private Vector2 seed;


    public void CreateWorld()
    {
        WorldInfo info = new WorldInfo
        {
            id = Guid.NewGuid().ToString(),
            name = inputField.text,
            seed = new Vector2(Random.Range(0, 10000), Random.Range(0, 10000))
        };

        list.worlds.Add(info);
        WorldStorage.SaveList(list);
        SpawnCard(info);

    }

    public void SpawnCard(WorldInfo info)
    {
        WorldCard card = Instantiate(worldCardPrefab, scrollRect.content);
        card.Setup(info);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        list = WorldStorage.LoadList();
        foreach (WorldInfo info in list.worlds)
        {
            SpawnCard(info);
        }
    }

}
