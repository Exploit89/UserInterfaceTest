using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Slider))]

public class HitPointsBarChanger : MonoBehaviour
{
    [SerializeField] private Slider _hitPointsBar;
    [SerializeField] private HitPointsChanger _hitPointsChanger;
    [SerializeField] private float _maxDelta;

    private Coroutine _currentCoroutine;
    private float _currentHitPonitBarValue;

    private void Start()
    {
        _currentHitPonitBarValue = _hitPointsChanger.CurrentHitPointsNumber;
        _hitPointsChanger.HittingActivated.AddListener(ValueChange);
        _hitPointsChanger.HealingActivated.AddListener(ValueChange);
    }

    public void ValueChange()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        if (_hitPointsChanger.IsHealing || _hitPointsChanger.IsHitting)
            _currentCoroutine = StartCoroutine(ChangeHitPointsValue(_hitPointsChanger.CurrentHitPointsNumber));
    }

    private IEnumerator ChangeHitPointsValue(float value)
    {
        var _waitingTime = new WaitForSeconds(0.5f);

        while (_hitPointsBar.value != value)
        {
            _hitPointsBar.value = Mathf.MoveTowards(_currentHitPonitBarValue, _hitPointsChanger.CurrentHitPointsNumber, _maxDelta);
            yield return _waitingTime;
        }
    }
}
