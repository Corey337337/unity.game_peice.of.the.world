using UnityEngine;
using UnityEngine.Audio;

public class World : MonoBehaviour
{
    [Header("Данные")]
    public int visibleWorldSize;//сколько чанков существует (3*3 = 9)

    [Header("Объекты")]
    public GameObject player;
    public Chunk chunk;
    public Generator generator;

    public void CheckChunks()
    {

    }

    public void BuildWorld()
    {
        for (int i = 0; i < visibleWorldSize; i++)
        {
            for (int j = 0; j < visibleWorldSize; j++)
            {
                var a = Instantiate(chunk, new Vector3(i * chunk.width, j * chunk.height, 0), Quaternion.identity, transform);
                a.GenerateChunk(generator);
            }
        }
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BuildWorld();
        player.GetComponent<PlayerLocation>().PlayerSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
