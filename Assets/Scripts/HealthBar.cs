using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _hitPointBar;
    [SerializeField] private Health _hitPoint;
    [SerializeField] private float _maxDelta;
    [SerializeField] private Text _currentHitPoints;

    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitingTime;

    private void Start()
    {
        _hitPointBar.value = _hitPoint.CurrentHitPointsNumber;
        _hitPoint.HittingActivated += ValueChange;
        _hitPoint.HealingActivated += ValueChange;
        _waitingTime = new WaitForSeconds(0.1f);
    }

    public void ValueChange()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeHitPointsValue(_hitPoint.CurrentHitPointsNumber));
        _currentHitPoints.text = $"{_hitPoint.CurrentHitPointsNumber}";
    }

    private void OnDestroy()
    {
        _hitPoint.HittingActivated -= ValueChange;
        _hitPoint.HealingActivated -= ValueChange;
    }

    private IEnumerator ChangeHitPointsValue(float value)
    {
        while (_hitPointBar.value != value)
        {
            _hitPointBar.value = Mathf.MoveTowards(_hitPointBar.value, _hitPoint.CurrentHitPointsNumber, _maxDelta);
            yield return _waitingTime;
        }
    }
}
