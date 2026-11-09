using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LootDropComponent : MonoBehaviour
{

    public GameObject item;

    public void GiveItem()
    {
        if (item != null)
        {
            var i = Instantiate(item);
            i.transform.position = GetComponent<Transform>().position;
        }
    }

    private void OnEnable()
    {
        GetComponent<HealthComponent>().OnDie += GiveItem;
    }

    private void OnDisable()
    {
        GetComponent<HealthComponent>().OnDie -= GiveItem;
    }

}
