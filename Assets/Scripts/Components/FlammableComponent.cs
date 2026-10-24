using System.Collections;
using UnityEngine;

public class FlammableComponent : MonoBehaviour
{

    public bool isBurning = false;


    private HealthComponent health;
    private Coroutine burnRoutine;



    void Awake()
    {
        health = GetComponent<HealthComponent>();
    }

    public void Ignite(float damage, float duration, float cooldown)
    {
        StartCoroutine(BurnRoutine(damage, duration, cooldown));
    }

    IEnumerator BurnRoutine(float damage, float duration, float cooldown)
    {
        isBurning = true;
        float hitCount = 0;

        while(hitCount < duration)
        {
            yield return new WaitForSeconds(cooldown);
            health.TakeDamage(damage);
            hitCount += 1;
        }

        
        isBurning = false;
        burnRoutine = null;
    }
    
}
