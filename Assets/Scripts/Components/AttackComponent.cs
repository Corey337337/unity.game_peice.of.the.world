using UnityEngine;
using System.Collections;

public class AttackComponent : MonoBehaviour
{
    public float damage;
    public float cooldown;
    public float activeTime;

    private float nextAttackTime;
    private bool isAttack = false;

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
                health.TakeDamage(damage);
                isAttack = false;
            }
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
