using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.Rendering.DebugUI;

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

    private Dictionary<Vector2Int, int[]> existingСhunks = new Dictionary<Vector2Int, int[]>();


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

    public void GenerateNewChunks() //необходимо зафиксировать данные в словарь 
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

                //начну писать логику тут но потом если необходимо будет создам новый метод
                if (existingСhunks.ContainsKey(cord))
                {
                    int[] ids = existingСhunks[cord];

                    //Debug.Log(string.Join(", ", ids));
                    int index = 0;
                    for (int i = 0; i < c.width; i++)
                    {
                        for (int j = 0; j < c.height; j++)
                        {
                            var block = Instantiate(generator.possibleBlocks[ids[index]], c.transform);
                            block.transform.localPosition = new Vector3(i, j, 0);
                            block.transform.localRotation = Quaternion.identity;

                            c.blocksInChunk.Add(block);
                            index++;
                        }
                    }
                }
                else
                {
                    //создаем новый и добавляем в словарь
                    c.GenerateChunk(generator);//создаем новый

                    int[] ids = new int[c.height * c.width];
                    for (int i = 0; i < c.blocksInChunk.Count; i++)
                    {
                        ids[i] = c.blocksInChunk[i].blockID;
                    }
                    existingСhunks.Add(cord, ids);//добавляем в словарь
                }
                
                //c.GenerateChunk(generator);//это надо убрать потом 
               
                ListChunks.Add(c);
            }
        }
        DeleteChunks(spisok);//мы передаем список не того что нужно удалить а то с чем сравнивать
    }

    private List<Chunk> chunksToDelete = new List<Chunk>();
    public void DeleteChunks(List<Vector2Int> spisok) //необходимо зафиксировать данные в словарь ?????или нет?????
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

   
    public void BuildWorld()//необходимо зафиксировать данные в словарь 
    {
        for (int i = 0; i < visibleWorldSize; i++)
        {
            for (int j = 0; j < visibleWorldSize; j++)
            {
                var c = Instantiate(chunk, new Vector3(i * chunk.width, j * chunk.height, 0), Quaternion.identity, transform);

                c.chunkPosition = new Vector2Int(i, j);

                c.GenerateChunk(generator);

                int[] ids = new int[c.height * c.width];

                for (int k = 0; k < c.blocksInChunk.Count; k++)
                {
                    ids[k] = c.blocksInChunk[k].blockID;
                }
                existingСhunks.Add(c.chunkPosition, ids);

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
