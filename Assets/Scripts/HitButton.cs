using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private HitPointsChanger _hitPointsChanger;

    private float _hitPointChangeStep = 10f;

    public void OnClick()
    {
        _hitPointsChanger.Hit(_hitPointChangeStep);
    }
}
