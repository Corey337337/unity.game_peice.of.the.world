using System;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float health;

    public event Action OnTakeDamage;
    public event Action OnDie;

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnTakeDamage?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDie?.Invoke();
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
