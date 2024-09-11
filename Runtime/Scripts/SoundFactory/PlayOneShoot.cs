using System;
using System.Collections;
using UnityEngine;

namespace naa.Module
{
    public abstract class PlayOneShoot : MonoBehaviour
    {
        [SerializeField] protected AudioSource _audioSource;

        public void Play(AudioClip audioClip)
        {
            StartCoroutine(PlayProcess(audioClip, null));
        }

        public void Play(AudioClip audioClip, Action action)
        {
            StartCoroutine(PlayProcess(audioClip, action));
        }

        private IEnumerator PlayProcess(AudioClip audioClip, Action onEnd)
        {
            _audioSource.PlayOneShot(audioClip);
            yield return new WaitForSeconds(audioClip.length);
            if (onEnd != null)
            {
                onEnd();
            }
            Destroy(gameObject);
        }
    }
}
