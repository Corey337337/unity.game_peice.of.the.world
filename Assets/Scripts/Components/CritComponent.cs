using UnityEngine;
using System;

public class CritComponent : MonoBehaviour
{

    public float critChance;
    public float critDamage;

    public event Action OnCrit;

    public float CalculateDamage(float damage)
    {
        if (UnityEngine.Random.value <= critChance)
        {
            OnCrit?.Invoke();
            Debug.Log("Крит!!!!!");
            return damage * (1 + critDamage);
        }
        else
        {
            return damage;
        }
    }
}
