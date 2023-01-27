using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Health _hitPoint;

    private float _healPointChangeStep = 10f;

    public void OnClick()
    {
        _hitPoint.Heal(_healPointChangeStep);
    }
}
