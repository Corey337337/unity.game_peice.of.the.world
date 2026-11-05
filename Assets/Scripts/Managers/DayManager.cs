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


    public bool isNight;

    public AnimationCurve lightCurve = new AnimationCurve(
       new Keyframe(0f, 1f),
       new Keyframe(0.6f, 1f),
       new Keyframe(0.65f, 0.15f),
       new Keyframe(0.95f, 0.15f),
       new Keyframe(1f, 1f)
   );

    public event Action OnNightStarts;
    public event Action OnNightEnds;

    void Start()
    {
        isNight = currentTimeCounter >= nightStartTime;
    }

    void Update()
    {
        currentTimeCounter += Time.deltaTime;

        if (currentTimeCounter >= nightStartTime && !isNight)
        {
            isNight = true;
            OnNightStarts?.Invoke();
        }

        if(currentTimeCounter >= allDay)
        {
            currentTimeCounter = 0f;

            if (isNight)
            {
                isNight = false;
                OnNightEnds?.Invoke();
            }
        }

        float t = currentTimeCounter / allDay;
        globalLight.intensity = lightCurve.Evaluate(t);

    }


}
