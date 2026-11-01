using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class DayManager : MonoBehaviour
{
    public Light2D globalLight;

    public float currentTimeCounter;

    [Header("Время (в секундах)")]
    public float allDay = 300f; //условно 5 мин 
    public float nightStartTime = 180f; //две из которых это ночь

    [Header("Свет")]
    public float transitionDuration = 15f;
    public float dayIntensity = 1f;
    public float nightIntensity = 0.2f;

    public bool isNight;

    public event Action OnNightStarts;
    public event Action OnNightEnds;

    void Start()
    {
        globalLight.intensity = 1; //потом по сохранению буду смотреть и загружать
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeCounter += Time.deltaTime;
        if (currentTimeCounter >= 180 && !isNight)
        {
            nightStart();
        }
        if(currentTimeCounter >= allDay)
        {
            currentTimeCounter = 0f;  //обнуляю

            nightEnd();
        }

    }

    public void nightStart()
    {
        isNight = true;
        OnNightStarts?.Invoke();
        
    }
    public void nightEnd()
    {
        isNight = false;
        OnNightEnds?.Invoke();
    }

}
