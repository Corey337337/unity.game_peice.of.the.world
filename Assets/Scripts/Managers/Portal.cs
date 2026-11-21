using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public static Portal Instance;

    public int stones = 50;
    public bool isActive { get; private set; }

    public event Action OnActive;

    void Awake()
    {
        Instance = this;
        isActive = GameSession.Data.portalsActive;
    }

    public void Activate()
    {
        if (isActive) return;

        isActive = true;
        GameSession.Data.portalsActive = true;
        GameSession.Save();
        OnActive?.Invoke();
    }
}
