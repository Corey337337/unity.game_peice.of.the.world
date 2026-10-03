using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropSpawner : MonoBehaviour
{
    public List<Prop> possibleProps;

    public float spawnChance;


    public void SpawnProp()
    {
        if (possibleProps.Count <= 0)
        {
            return;
        }
        float randNum = Random.Range(0f, 1f);
        if (randNum <= spawnChance)
        {
            int randomProp = Random.Range(0, possibleProps.Count);
            possibleProps[randomProp].gameObject.SetActive(true);
        }
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
