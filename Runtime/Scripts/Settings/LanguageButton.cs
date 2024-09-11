using System;
using UnityEngine;
using UnityEngine.UI;

public class LanguageButton : MonoBehaviour
{
    public event Action<string> OnLanguageChanged;

    public string Key => _languageKey[_languageIndex];

    [SerializeField] private Text _text;
    [SerializeField] private Button _button;

    private string[] _languageKey = new string[] { "en", "ru" };
    private int _languageIndex = 0;

    private void Awake()
    {
        _button.onClick.AddListener(Clickhandler);
    }

    public void Fill(string key)
    {
        _languageIndex = GetIndex(key);
    }

    private void Clickhandler()
    {
        if (_languageIndex == _languageKey.Length - 1)
        {
            _languageIndex = -1;
        }

        _languageIndex++;
        _text.text = Key;
        OnLanguageChanged?.Invoke(Key);
    }

    private int GetIndex(string key)
    {
        for (var i = 0; i < _languageKey.Length; i++)
        {
            if (_languageKey[i] == key)
            {
                return i;
            }
        }

        return -1;
    }
}
