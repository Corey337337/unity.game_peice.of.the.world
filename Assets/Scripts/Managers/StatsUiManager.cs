using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatsUiManager : MonoBehaviour
{
    [Header("ХП")]
    public Slider hpSlider;
    public TextMeshProUGUI hpText;
    public HealthComponent healthComponent;

    [Header("Урон")]
    public TextMeshProUGUI damageText;
    public AttackComponent attackComponent;

    [Header("Крит Урон")]
    public TextMeshProUGUI critChanceText;
    public TextMeshProUGUI critDamageText;
    public CritComponent critComponent;

    [Header("Уровень")]
    public Slider levelSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI levelTextProgress;
    LevelingManager leveling;


    public void UpdateHP()
    {
        hpSlider.maxValue = healthComponent.maxHealth;

        hpSlider.value = healthComponent.health;

        hpText.text = healthComponent.health.ToString();
    }

    public void UpdateDamage()
    {
        damageText.text = attackComponent.damage.ToString();
    }

    public void UpdateCrit()
    {
        critChanceText.text = (critComponent.critChance * 100f).ToString() + "%";
        critDamageText.text = (critComponent.critDamage * 100f).ToString() + "%";
    }

    public void UpdateLevel()
    {

        levelText.text = leveling.level + " УР.";

        levelSlider.maxValue = leveling.XpToNextLevel();

        levelSlider.value = leveling.currentXP;

        levelTextProgress.text = leveling.currentXP + $"/{leveling.XpToNextLevel()}";


    }


    private void OnDisable()
    {
        leveling.OnLevelUp2 -= UpdateLevel;
        leveling.OnPlusXP -= UpdateLevel;
    }

    void Start()
    {
        leveling = LevelingManager.Instance;
        leveling.OnLevelUp2 += UpdateLevel;
        leveling.OnPlusXP += UpdateLevel;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateHP();
        UpdateDamage();
        UpdateCrit();
    }
}
