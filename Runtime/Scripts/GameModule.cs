using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Settings = naa.Module.Settings;

namespace naa.Module
{
    public class GameModule : MonoBehaviour
    {
        public static GameModule Instance { get; private set; }

        [field: SerializeField] public EffectFactory EffectFactory { get; private set; }
        [field: SerializeField] public SoundFactory SoundFactory { get; private set; }
        [field: SerializeField] public Settings Settings { get; private set; }

        [SerializeField] private SettingsView _settingsView;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void ShowDevPanel()
        {
            _settingsView.gameObject.SetActive(!_settingsView.gameObject.activeSelf);
        }
    }
}
