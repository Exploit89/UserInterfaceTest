using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HitPointsChanger : MonoBehaviour
{
    [SerializeField] private Slider _playerHitPointsBar;
    [SerializeField] private Text _currentHitPoints;
    private float _currentHitPointsNumber;
    private float _minHitPoints = 0f;
    private float _maxHitPoints = 100f;

    void Start()
    {
        _currentHitPoints.DOText("100", 0);
        _currentHitPointsNumber = 100f;
    }

    public void Heal()
    {
        if (_currentHitPointsNumber < _maxHitPoints) 
        {
            _currentHitPointsNumber += 10f;
            _playerHitPointsBar.DOValue(_currentHitPointsNumber, 1);
            _currentHitPoints.DOText(_currentHitPointsNumber.ToString(), 0);
        }
    }

    public void Hit()
    {
        if (_currentHitPointsNumber > _minHitPoints)
        {
            _currentHitPointsNumber -= 10f;
            _playerHitPointsBar.DOValue(_currentHitPointsNumber, 1);
            _currentHitPoints.DOText(_currentHitPointsNumber.ToString(), 0);
        }
    }
}
