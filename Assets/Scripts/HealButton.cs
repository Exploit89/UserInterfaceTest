using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private HitPointsChanger _hitPointsChanger;

    public void OnClick()
    {
        _hitPointsChanger.Heal();
    }
}
