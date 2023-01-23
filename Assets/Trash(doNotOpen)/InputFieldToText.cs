using UnityEngine;
using TMPro;

public class InputFieldToText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void ToText(string str)
    {
        _text.text = str;
    }
}
