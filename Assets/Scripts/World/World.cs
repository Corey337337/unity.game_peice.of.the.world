using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

public class World : MonoBehaviour
{
    [Header("Данные")]
    public int visibleWorldSize;

    [Header("Объекты")]
    public GameObject player;
    public Chunk chunk;
    public Generator generator;

    private Vector2Int CurrentChunk;
    private Vector2Int PreviousChunk;
    private List<Chunk> ListChunks = new List<Chunk>();

    public static World Instance;
    void Awake() 
    { 
        Instance = this; 
    }

    public Vector2Int GetCurrentChunk()
    {
        
        int x = Mathf.FloorToInt(player.transform.position.x / chunk.width);
        int y = Mathf.FloorToInt(player.transform.position.y / chunk.height);

        return new Vector2Int(x, y);
    }


    public bool HasChanckAt(Vector3 pos)
    {
        int x = Mathf.FloorToInt(pos.x / chunk.width);
        int y = Mathf.FloorToInt(pos.y / chunk.height);
        return IsChunkExists(new Vector2Int(x, y));
    }

    public List<Vector2Int> GetNeighboursCords()
    {
        CurrentChunk = GetCurrentChunk();
        List<Vector2Int> neighboursCords = new List<Vector2Int>();

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                var cord_x = CurrentChunk.x + dx;
                var cord_y = CurrentChunk.y + dy;

                neighboursCords.Add(new Vector2Int(cord_x, cord_y));

            }
        }
        return neighboursCords;
    }

    public bool IsChunkExists(Vector2Int position)
    {
        for (int i = 0; i < ListChunks.Count; i++)
        {
            if (ListChunks[i].chunkPosition == position)
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateNewChunks()
    {
        List<Vector2Int> spisok = GetNeighboursCords();

        foreach (Vector2Int cord in spisok)
        {
            if (!IsChunkExists(cord))
            {
                //создается оболочка чанка
                var c = Instantiate(chunk, new Vector3(cord.x * chunk.width, cord.y * chunk.height, 0), Quaternion.identity, transform);
                //затем этой оболочке присваиваются координаты
                c.chunkPosition = cord;

                c.GenerateChunk(generator);

                ListChunks.Add(c);

            }
        }
        DeleteChunks(spisok);//мы передаем список не того что нужно удалить а то с чем сравнивать
    }

    private List<Chunk> chunksToDelete = new List<Chunk>();
    public void DeleteChunks(List<Vector2Int> spisok)
    {
        foreach (var c in ListChunks)
        {
            if (!spisok.Contains(c.chunkPosition))
            {
                chunksToDelete.Add(c);
            }
        }

        foreach (var c in chunksToDelete)
        {
            ListChunks.Remove(c);
            Destroy(c.gameObject);
        }
        chunksToDelete.Clear();
    }

   
    public void BuildWorld()
    {
        for (int i = 0; i < visibleWorldSize; i++)
        {
            for (int j = 0; j < visibleWorldSize; j++)
            {
                var c = Instantiate(chunk, new Vector3(i * chunk.width, j * chunk.height, 0), Quaternion.identity, transform);

                c.chunkPosition = new Vector2Int(i, j);

                c.GenerateChunk(generator);

                ListChunks.Add(c);
            }
        }
    }

    

    void Start()
    {
        BuildWorld();
        player.GetComponent<PlayerLocation>().PlayerSpawn();

        CurrentChunk = GetCurrentChunk();
        PreviousChunk = CurrentChunk;
    }

    void Update()
    {
        Vector2Int newChunk = GetCurrentChunk();

        if (newChunk != CurrentChunk)
        {
            PreviousChunk = CurrentChunk;
            CurrentChunk = newChunk;

            GenerateNewChunks();
          
        }
    }
}
