using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Tree : MonoBehaviour
{
    public Item applePrefab;

    public float spawnChance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float random = Random.Range(0f, 1f);

        if(random <= spawnChance)
        {
            var apple = Instantiate(applePrefab, transform);
            apple.transform.localPosition = new Vector2(0, -0.3f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
