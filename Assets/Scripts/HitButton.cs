using UnityEngine;

public class HitButton : MonoBehaviour
{
    [SerializeField] private HitPointsChanger _hitPointsChanger;

    public void OnClick()
    {
        _hitPointsChanger.Hit();
    }
}
