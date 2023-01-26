using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private HitPointsChanger _hitPoint;

    private float _hitPointChangeStep = 10f;

    public void OnClick()
    {
        _hitPoint.Hit(_hitPointChangeStep);
    }
}
