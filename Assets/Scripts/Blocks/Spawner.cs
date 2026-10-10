using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Spawner : MonoBehaviour
{
    public List<GameObject> possibleItems;

    public float spawnChance;

    public Block block;

    public void Spawn()
    {
        if (possibleItems.Count <= 0)
        {
            return;
        }

        if (checkChance())
        {
            int randomProp = Random.Range(0, possibleItems.Count);
            var prop = Instantiate(possibleItems[randomProp], block.transform.position, Quaternion.identity);
            //var prop = Instantiate(possibleItems[randomProp], transform);
            //prop.transform.position = new Vector2(block.globalX, block.globalY);

            //эксперименты
            //possibleItems[randomProp] = Instantiate(block.getPosition(), transform);//не обращай внимания я просто вспоминал синтаксис
            //possibleItems[randomProp].transform.position = new Vector2(block.getPosition());
            //possibleItems[randomProp].gameObject.SetActive(true);//замена логики
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
