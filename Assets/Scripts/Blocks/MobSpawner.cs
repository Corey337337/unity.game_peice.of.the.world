using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class MobSpawner : MonoBehaviour
{
    public List<Mob> possibleMobs;

    public float spawnChance;

    public void Spawn()
    {
        if (checkChance())
        {
            int randomMob = Random.Range(0, possibleMobs.Count);
            possibleMobs[randomMob].gameObject.SetActive(true);
            //return possibleMobs[randomMob];
        }
        
    }

    public bool checkChance()//замечание спавнеры (декораций и мобов) делают одно и тже но код дублируется. необходимо исправить
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
