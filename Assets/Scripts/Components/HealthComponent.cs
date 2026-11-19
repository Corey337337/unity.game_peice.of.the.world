using System;
using UnityEngine;
using System.Collections;

public class HealthComponent : MonoBehaviour
{

    public float maxHealth;
    public float health;
    

    public event Action OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDie;

    private SpriteRenderer sr;//возможно в будущем придется сделать отдельный скрипт для покраски мобов
                              //(например от эффектов а не только от получения урона)


    private IEnumerator ColorRoutine()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(ColorRoutine());
        //Debug.Log($"осталось здоровья - {health}");
        OnTakeDamage?.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Healing(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        Debug.Log($"отхил. теперь здоровья - {health}");
        OnHeal?.Invoke();
    }

    public void Die()
    {
        //Debug.Log($"умер");
        OnDie?.Invoke();
        Destroy(gameObject);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }
}
