using System;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public Vector2Int chunkPosition;
    public int height;
    public int width;

    public event Action OnChunkSpawn;

    public List<Block> blocksInChunk;

    public void GenerateChunk(Generator generation)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                int globalX = chunkPosition.x * width + i;
                int globalY = chunkPosition.y * height + j;

                var block = Instantiate(generation.GenerateBlocksInChunk(globalX, globalY), transform);
                block.globalX = globalX;
                block.globalY = globalY;
                block.transform.localPosition = new Vector3(i, j, 0);
                block.transform.localRotation = Quaternion.identity;


                foreach (var s in block.spawners)//теперь происходит подписка всех спавнеров блока
                {
                    OnChunkSpawn += s.Spawn;
                }
                //а не как тут (каждый отдельно)
                //OnChunkSpawn += block.GetComponent<PropSpawner>().Spawn;
                //OnChunkSpawn += block.GetComponent<MobSpawner>().Spawn;

                blocksInChunk.Add(block);

            }
        }
        OnChunkSpawn?.Invoke();
    }

}
