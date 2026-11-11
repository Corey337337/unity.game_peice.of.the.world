using UnityEngine;

public class XP_GiverComponent : MonoBehaviour
{
    public int xp;

    //public LevelingManager leveling;

    private HealthComponent health;

    public void xpGive()
    {
        LevelingManager.Instance.AddXp(xp);
    }

    private void Awake()
    {
        health = GetComponent<HealthComponent>();
    }

    private void OnEnable()
    {
        health.OnDie += xpGive;
    }
    private void OnDisable()
    {
        health.OnDie -= xpGive;
    }

}
