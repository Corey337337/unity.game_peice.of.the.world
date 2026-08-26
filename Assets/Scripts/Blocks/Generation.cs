using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class Generation : MonoBehaviour  //экспериментальный скрипт генерации блоков
{
   
    // пока что один префаб который назначается в инспекторе
    // потом будет рандомная генерация из списка (шансы и прочее прошипу позже)

    //public Block blockObject; //заменить на лист блоков и потом рандомить их появление
    public List<Block> possibleBlocks;//вот
    public Chunk chunkObject;

    public GameObject playerObject;

    public Block GenerateBlocksInChunk()
    {
        int randomBlock = Random.Range(0, possibleBlocks.Count);
        return possibleBlocks[randomBlock];
    }

    public void GenerateChunk()
    {
       for (int i = 0; i < chunkObject.width; i++)
       {
            for (int j = 0; j < chunkObject.height; j++)
            {
                Instantiate(GenerateBlocksInChunk(), new Vector3(i, j, 0), Quaternion.identity);
            }
       }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
