using UnityEngine;

public class XP_GiverComponent : MonoBehaviour
{
    public int xp;

    public LevelingManager leveling;

    private HealthComponent health;

    public void xpGive()
    {

        //LevelingManager.Instance.AddXp(xp); это правильное использование но на потом (исправлю позже)
        leveling.totalXp += xp;
        Debug.Log($"всего {leveling.totalXp} опыта");

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
