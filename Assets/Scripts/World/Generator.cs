using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    public List<Block> possibleBlocks;

    [Header("Настройки шума")]
    public float scale;
    public Vector2 offset;

    public int SeedInt
    {
        get
        {
            int x = (int)offset.x;
            int y = (int)offset.y;
            return x * 73856093 + y * 19349663;
            
        }
    }

    public static int CellHash(int seed, int x, int y, int salt)
    {
        unchecked
        {
            uint h = 2166136261;
            h = (h ^ (uint)seed) * 16777619;
            h = (h ^ (uint)x) * 16777619;
            h = (h ^ (uint)y) * 16777619;
            h = (h ^ (uint)salt) * 16777619;
            return (int)h;
        }
    }


    private void Awake()
    {
        if (GameSession.CurrentWorld == null)
        {
            offset = new Vector2(Random.Range(0, 10000), Random.Range(0, 10000));
            return;
        }

        offset = GameSession.CurrentWorld.seed;
    }

    public Block GenerateBlocksInChunk(int globalX, int globalY)
    {
        float noiseValue = Mathf.PerlinNoise((globalX + offset.x) * scale,(globalY + offset.y) * scale);

        return GetBlockByNoise(noiseValue);
    }


    public Block GetBlockByNoise(float value)
    {
        if (value < 0.14)//0.3
            return possibleBlocks[1];
        else if (value < 0.22)//0.4
            return possibleBlocks[2];
        else if (value < 0.57)//0.75
            return possibleBlocks[0];
        else if (value < 0.7)
            return possibleBlocks[4];
        else 
            return possibleBlocks[3];//5 

    }
}
