using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string label = "Без названия";
    public List<GameObject> possibleObjects;

    public float spawnChance;

    public Block block;

    public bool deterministic = true;

    public void Spawn()
    {
        if (possibleObjects.Count <= 0)
        {
            return;
        }

        float roll;
        int index;

        if (deterministic)
        {
            int salt = block.spawners.IndexOf(this);

            int seed = World.Instance.generator.SeedInt;

            var rng = new System.Random(Generator.CellHash(seed, (int)block.globalX, (int)block.globalY, salt));


            roll = (float)rng.NextDouble();
            index = rng.Next(possibleObjects.Count);
        }
        else
        {
            roll = Random.value;
            index = Random.Range(0, possibleObjects.Count);
        }

        

        if (roll > spawnChance)
        {
            return;
        }

        Transform parent;

        if (deterministic)
        {
            parent = block.transform.parent;
        }
        else
        {
            parent = null;
        }


        Instantiate(possibleObjects[index], block.transform.position, Quaternion.identity, parent);

    }

    //public bool checkChance()
    //{
    //    float randNum = Random.Range(0f, 1f);
    //    if (randNum <= spawnChance)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    
}
