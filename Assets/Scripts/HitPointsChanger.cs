using System;
using UnityEngine;
using UnityEngine.UI;

public class HitPointsChanger : MonoBehaviour
{
    [SerializeField] private Text _currentHitPoints;

    private float _minHitPoints = 0f;
    private float _maxHitPoints = 100f;

    public float CurrentHitPointsNumber { get; private set; }

    public event Action HealingActivated;
    public event Action HittingActivated;

    void Start()
    {
        CurrentHitPointsNumber = _maxHitPoints;
    }

    public void Heal(float healValue)
    {
        CurrentHitPointsNumber += healValue;
        CurrentHitPointsNumber = Mathf.Clamp(CurrentHitPointsNumber, _minHitPoints, _maxHitPoints);
        _currentHitPoints.text = $"{CurrentHitPointsNumber}";
        HealingActivated?.Invoke();
    }

    public void Hit(float hitValue)
    {
        CurrentHitPointsNumber -= hitValue;
        CurrentHitPointsNumber = Mathf.Clamp(CurrentHitPointsNumber, _minHitPoints, _maxHitPoints);
        _currentHitPoints.text = $"{CurrentHitPointsNumber}";
        HittingActivated?.Invoke();
    }
}
