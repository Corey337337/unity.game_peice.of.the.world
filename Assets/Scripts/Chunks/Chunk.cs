using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public Vector2Int chunkPosition;
    public int height;
    public int width;

    public List<Block> blocksInChunk;


    public void GenerateChunk(Generation generation)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Instantiate(generation.GenerateBlocksInChunk(), new Vector3(i, j, 0), Quaternion.identity, transform);
            }
        }
    }

}
