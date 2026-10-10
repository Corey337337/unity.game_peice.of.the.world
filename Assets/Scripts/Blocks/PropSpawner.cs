using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropSpawner : MonoBehaviour
{
    public List<Prop> possibleProps;

    public float spawnChance;


    public void Spawn()
    {
        if (possibleProps.Count <= 0)
        {
            return;
        }

        if (checkChance())
        {
            int randomProp = Random.Range(0, possibleProps.Count);
            possibleProps[randomProp].gameObject.SetActive(true);
        }
        
    }

    public bool checkChance()
    {
        float randNum = Random.Range(0f, 1f);
        if (randNum <= spawnChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
}
