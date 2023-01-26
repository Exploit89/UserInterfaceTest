using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(HitPointsChanger))]

public class HitPointsBarChanger : MonoBehaviour
{
    [SerializeField] private Slider _hitPointBar;
    [SerializeField] private HitPointsChanger _hitPoint;
    [SerializeField] private float _maxDelta;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        _hitPointBar.value = _hitPoint.CurrentHitPointsNumber;
        _hitPoint.HittingActivated += ValueChange;
        _hitPoint.HealingActivated += ValueChange;
    }

    public void ValueChange()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeHitPointsValue(_hitPoint.CurrentHitPointsNumber));

        if (_hitPoint.CurrentHitPointsNumber <= 0)
        {
            _hitPoint.HittingActivated -= ValueChange;
            _hitPoint.HealingActivated -= ValueChange;
        }
    }

    private IEnumerator ChangeHitPointsValue(float value)
    {
        var _waitingTime = new WaitForSeconds(0.1f);

        while (_hitPointBar.value != value)
        {
            _hitPointBar.value = Mathf.MoveTowards(_hitPointBar.value, _hitPoint.CurrentHitPointsNumber, _maxDelta);
            yield return _waitingTime;
        }
    }
}
