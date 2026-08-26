using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{

    public List<Block> possibleBlocks;

    public Block GenerateBlocksInChunk()
    {
        int randomBlock = Random.Range(0, possibleBlocks.Count);
        return possibleBlocks[randomBlock];
    }

}
