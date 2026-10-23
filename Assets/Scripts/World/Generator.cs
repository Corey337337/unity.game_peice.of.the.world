using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    public List<Block> possibleBlocks;

    [Header("Настройки шума")]
    public float scale;
    public Vector2 offset;


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
        //int randomBlock = Random.Range(0, possibleBlocks.Count);
        //return possibleBlocks[randomBlock];
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
            return possibleBlocks[3];

    }
}
