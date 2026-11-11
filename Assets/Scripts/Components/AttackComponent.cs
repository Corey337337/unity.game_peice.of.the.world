using UnityEngine;
using System.Collections;
using System;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    public float cooldown;
    public float activeTime;
    private bool isAttack = false;


    private CritComponent critComponent;

    public event Action<GameObject> OnHit;

    private float nextAttackTime;
   

    public void TryAttack()
    {
        if (Time.time < nextAttackTime)
        {
            return;
        }
        else
        {
            nextAttackTime = Time.time + cooldown;
            StartCoroutine(AttackRoutine());
        }
    }

    private IEnumerator AttackRoutine()
    {
        isAttack = true;
        //Debug.Log("атакую!!!");
        yield return new WaitForSeconds(activeTime);
        isAttack = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (isAttack)
        {
            var health = other.GetComponent<HealthComponent>();

            if (health != null)
            {
                float finalDamage = damage;

                if (critComponent != null) 
                {
                    finalDamage = critComponent.CalculateDamage(damage);
                }

                health.TakeDamage(finalDamage);
                OnHit?.Invoke(other.gameObject);

                isAttack = false;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        critComponent = GetComponent<CritComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
