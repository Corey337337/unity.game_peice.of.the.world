using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Audio;

public class World : MonoBehaviour
{
    [Header("Данные")]
    public int visibleWorldSize;//сколько чанков существует (3*3 = 9)

    [Header("Объекты")]
    public GameObject player;
    public Chunk chunk;
    public Generator generator;

    private Vector2Int CurrentChunk;
    private Vector2Int PreviousChunk;
    private List<Chunk> ListChunks = new List<Chunk>();



    public Vector2Int GetCurrentChunk()
    {
        int x = Mathf.FloorToInt(player.transform.position.x / chunk.width);
        int y = Mathf.FloorToInt(player.transform.position.y / chunk.height);

        return new Vector2Int(x, y);
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

    public void SvuazZveno()//временное название
    {
        List<Vector2Int> spisok = GetNeighboursCords();

        foreach (Vector2Int cord in spisok)
        {
            if (!IsChunkExists(cord))
            {
                var c = Instantiate(chunk, new Vector3(cord.x * chunk.width, cord.y * chunk.height, 0), Quaternion.identity, transform);
                c.chunkPosition = cord;
                c.GenerateChunk(generator);

                ListChunks.Add(c);
            }
        }
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

            SvuazZveno();
          
        }
    }
}
