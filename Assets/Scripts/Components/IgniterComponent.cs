using UnityEngine;

[RequireComponent(typeof(AttackComponent))]
public class IgniterComponent : MonoBehaviour
{
    public float burnDamage;
    public float duration;
    public float cooldown;

    private AttackComponent attack;

    void Awake()
    {
        attack = GetComponent<AttackComponent>();
    }

    private void OnEnable()
    {
        attack.OnHit += BurnHit;
    }

    private void OnDisable()
    {
        attack.OnHit -= BurnHit;
    }

    public void BurnHit(GameObject target)
    {
        var flammable = target.GetComponent<FlammableComponent>();

        if (flammable != null)
        {
            flammable.Ignite(burnDamage, duration, cooldown);
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
