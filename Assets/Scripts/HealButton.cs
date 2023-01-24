using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private HitPointsChanger _hitPointsChanger;

    private float _healPointChangeStep = 10f;

    public void OnClick()
    {
        _hitPointsChanger.Heal(_healPointChangeStep);
    }
}
