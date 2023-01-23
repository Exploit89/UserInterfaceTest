using UnityEngine;

public class Toggle : MonoBehaviour
{
    [SerializeField] GameObject _text;

    public void OnToggleChanged(bool state)
    {
        _text.SetActive(state);
    }
}
