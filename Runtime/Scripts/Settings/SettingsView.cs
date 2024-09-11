using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : MonoBehaviour
{
    public event Action<SettingsData> OnSettingChange;
    public event Action OnPressBack;
    public event Action OnClearSave;

    [SerializeField] private Slider _sliderSound;
    [SerializeField] private Slider _sliderMusic;
    [SerializeField] private Toggle _isAgeLimit;
    [SerializeField] private LanguageButton _language;
    [SerializeField] private Button _back;
    [SerializeField] private Button _clearSave;

    private void Awake()
    {
        _sliderSound.onValueChanged.AddListener((value) => ChangeSettings());
        _sliderMusic.onValueChanged.AddListener((value) => ChangeSettings());
        _isAgeLimit.onValueChanged.AddListener((value) => ChangeSettings());
        _language.OnLanguageChanged += PressLanguageHandler;
        _back.onClick.AddListener(() => OnPressBack?.Invoke());
        _clearSave.onClick.AddListener(() => OnClearSave?.Invoke());
    }

    public void Fill(SettingsData settingsData)
    {
        _sliderSound.value = settingsData.Sound;
        _sliderMusic.value = settingsData.Music;
        _isAgeLimit.isOn = settingsData.IsAgeLimit;
        _language.Fill(settingsData.Language);
    }

    private void PressLanguageHandler(string key)
    {
        ChangeSettings();
    }

    private void ChangeSettings()
    {
        OnSettingChange?.Invoke(GetSettingsData());
    }

    private SettingsData GetSettingsData()
    {
        return new SettingsData(_sliderSound.value, _sliderMusic.value, _isAgeLimit.isOn, _language.Key);
    }
}
