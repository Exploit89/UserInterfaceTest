using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject _text;

    public void OnButtonClick()
    {
        Destroy(_text);
    }
}
