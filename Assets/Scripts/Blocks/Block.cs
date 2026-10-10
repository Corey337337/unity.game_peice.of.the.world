using UnityEngine;
using System.Collections.Generic;

public class Block : MonoBehaviour
{
    public string blockName;

    public int blockID;

    public List<Spawner> spawners; //для того чтобы было удобно подписывать спавнеры блоков в момент генерации чанка

    //public BiomeType biomeType; //откажусь пожалуй

    public float globalX;
    public float globalY;

    /*
    public Vector2 getPosition()
    {
        return new Vector2(globalX, globalY);
    }*/

   
}
