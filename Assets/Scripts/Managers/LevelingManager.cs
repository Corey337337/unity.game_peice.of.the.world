using UnityEngine;
using System;

public class LevelingManager : MonoBehaviour
{
    public static LevelingManager Instance { get; private set; }


    public int totalXP = 0; //наверна не нужен
    public int level = 1;
    public int currentXP = 0;
    public const int MaxLevel = 30;

    public event Action OnPlusXP;
    //public event Action<int> OnLevelUp;
    public event Action OnLevelUp2;

    private void Awake()
    {
        Instance = this;
    }

    public void AddXp(int xp)
    {
        totalXP += xp;
        currentXP += xp;
        OnPlusXP?.Invoke();

        while (level < MaxLevel && currentXP >= XpToNextLevel())
        {
            currentXP -= XpToNextLevel();
            level++;
            OnLevelUp2?.Invoke();
            //OnLevelUp?.Invoke(level);
            Debug.Log($"Новый уровень: {level}");
        }

        Debug.Log($"Уровень {level}, опыта {currentXP}/{XpToNextLevel()}");
    }

    public int XpToNextLevel()
    {
        return Mathf.RoundToInt(3f * Mathf.Pow(level, 1.5f));
    }
}
