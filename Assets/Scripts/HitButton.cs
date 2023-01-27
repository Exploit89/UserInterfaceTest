using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private Health _hitPoint;

    private float _hitPointChangeStep = 10f;

    public void OnClick()
    {
        _hitPoint.Hit(_hitPointChangeStep);
    }
}
