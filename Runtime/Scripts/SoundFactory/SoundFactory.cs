using System;
using System.Linq;
using UnityEngine;

namespace naa.Module
{
    public class SoundFactory : MonoBehaviour
    {
        [SerializeField] private SoundData[] _soundDatas;
        [SerializeField] private PlayOneShootUI _playOneShootUI;
        [SerializeField] private PlayOneShootGame _playOneShootGame;

        public void PlayUI(string key)
        {
            var audioData = GetAudio(key);
            if (audioData == null)
            {
                return;
            }

            PlayUI(audioData.AudioClip);
        }

        public void PlayGame(string key, Transform perent)
        {
            PlayGame(key, perent.position, perent);
        }

        public void PlayGame(string key, Vector3 position)
        {
            PlayGame(key, position, transform);
        }

        public void PlayGame(string key, Vector3 position, Transform perent)
        {
            var audioData = GetAudio(key);
            if (audioData == null)
            {
                return;
            }

            PlayGame(audioData.AudioClip, position, perent);
        }

        private bool CheackEffect(string key)
        {
            return _soundDatas.Any(e => e.Key.Equals(key));
        }

        private SoundData GetAudio(string key)
        {
            if (!CheackEffect(key))
            {
                Debug.LogError($"SoundFactory >> GetAudio >> [Audio is not found]");
                return null;
            }

            return _soundDatas.FirstOrDefault(e => e.Key.Equals(key));
        }

        private void PlayUI(AudioClip audioClip)
        {
            Instantiate(_playOneShootUI, transform.position, Quaternion.identity, transform).Play(audioClip);
        }

        private void PlayGame(AudioClip audioClip, Vector3 position, Transform perent)
        {
            Instantiate(_playOneShootUI, position, Quaternion.identity, perent).Play(audioClip);
        }
    }

    [Serializable]
    public class SoundData
    {
        public string Key;
        public AudioClip AudioClip;
    }
}
