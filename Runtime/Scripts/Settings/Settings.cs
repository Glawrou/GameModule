using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace naa.Module
{
    public class Settings : MonoBehaviour
    {
        public static string Langugage { get; private set; }

        [SerializeField] private SettingsView _view;
        [SerializeField] private AudioMixer _mainMixer;
        [SerializeField] private Saver _saver;

        private float MinMixerValue = -80;

        private void Start()
        {
            FillSaveData(_saver.SaveData.Settings);
            _view.OnSettingChange += ChangeSettingHandler;
            _view.OnClearSave += ClearSaveHandler;
            _view.OnPressBack += ExitGame;
        }

        public void SetMusic(float value)
        {
            SetMixer("Music", value);
        }

        public void SetSound(float value)
        {
            SetMixer("Sound", value);
        }

        private void SetMixer(string key, float value)
        {
            value = Mathf.Clamp01(value);
            value = 1 - value;
            _mainMixer.SetFloat(key, value * MinMixerValue);
        }

        public void SetLanguage(string key)
        {
            Langugage = key;
            LocalizationSettings.SelectedLocale = GetLocale(key);
        }

        private void FillSaveData(SettingsData data)
        {
            ChangeSettingHandler(data);
            _view.Fill(data);
        }

        private void ClearSaveHandler()
        {
            _saver.Clear();
            _view.Fill(_saver.SaveData.Settings);
        }

        private void ChangeSettingHandler(SettingsData data)
        {
            SetMusic(data.Music);
            SetSound(data.Sound);
            SetLanguage(data.Language);
            _saver.SaveData.Settings = data;
            _saver.Save();
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private Locale GetLocale(string key)
        {
            var list = LocalizationSettings.AvailableLocales.Locales;
            foreach (var locale in list)
            {
                if (locale.Identifier.Code == key)
                {
                    return locale;
                }
            }

            return null;
        }
    }
}
