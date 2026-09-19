using UnityEngine;
using System.Collections.Generic;

public class Chunk : MonoBehaviour
{
    public Vector2Int chunkPosition;
    public int height;
    public int width;

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
                block.transform.localPosition = new Vector3(i, j, 0);
                block.transform.localRotation = Quaternion.identity;

                blocksInChunk.Add(block);
            }
        }
    }

}
