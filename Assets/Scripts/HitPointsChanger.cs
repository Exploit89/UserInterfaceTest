using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HitPointsChanger : MonoBehaviour
{
    [SerializeField] private Text _currentHitPoints;

    private float _minHitPoints = 0f;
    private float _maxHitPoints = 100f;


    public bool IsHealing { get; private set; }
    public bool IsHitting { get; private set; }
    public float CurrentHitPointsNumber { get; private set; }
    public float HitPointsHealStep { get; private set; }
    public float HitPointsHitStep { get; private set; }


    public UnityEvent HealingActivated = new UnityEvent();
    public UnityEvent HittingActivated = new UnityEvent();

    void Start()
    {
        CurrentHitPointsNumber = _maxHitPoints;
        _currentHitPoints.text = $"{_maxHitPoints}";
    }

    public void Heal(float healValue)
    {
        if (CurrentHitPointsNumber < _maxHitPoints)
        {
            IsHealing= true;
            HealingActivated?.Invoke();
            CurrentHitPointsNumber += healValue;
            _currentHitPoints.text = $"{CurrentHitPointsNumber}";
        }

        //IsHealing = false;
    }

    public void Hit(float hitValue)
    {
        if (CurrentHitPointsNumber > _minHitPoints)
        {
            IsHitting = true;
            HittingActivated?.Invoke();
            CurrentHitPointsNumber -= hitValue;
            _currentHitPoints.text = $"{CurrentHitPointsNumber}";
        }

        //IsHitting = false;
    }
}
