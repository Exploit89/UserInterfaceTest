using UnityEngine;
using TMPro;

public class ToText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Dropdown _dropdown;

    public void DropdownToText(int num)
    {
        _text.text = _dropdown.options[num].text;
    }
}
