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


    private static float GetWeight(GameObject obj)
    {
        var s = obj.GetComponent<Spawnable>();
        if (s != null)
            return s.weight;
        else
            return 1f;
    }

    private GameObject PickWeighted(float pick)
    {
        float total = 0f;
        foreach (var obj in possibleObjects)
            total += GetWeight(obj);

        float target = pick * total;

        foreach (var obj in possibleObjects)
        {
            float w = GetWeight(obj);
            if (target < w) return obj;
            target -= w;
        }
        return possibleObjects[possibleObjects.Count - 1];
    }

    public void Spawn()
    {
        if (possibleObjects.Count <= 0)
        {
            return;
        }

        float roll;
        float pick;

        if (deterministic)
        {
            int salt = block.spawners.IndexOf(this);

            int seed = World.Instance.generator.SeedInt;

            var rng = new System.Random(Generator.CellHash(seed, (int)block.globalX, (int)block.globalY, salt));


            roll = (float)rng.NextDouble();
            pick = (float)rng.NextDouble();
        }
        else
        {
            roll = Random.value;
            pick = Random.value;
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

        GameObject chosen = PickWeighted(pick);
        Instantiate(chosen, block.transform.position, Quaternion.identity, parent);


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
