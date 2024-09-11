using UnityEngine;

namespace naa.Module
{
    public class PlayOnAwakeSoundGame : MonoBehaviour
    {
        [SerializeField] private string Key;

        private void Start()
        {
            GameModule.Instance.SoundFactory.PlayGame(Key, transform.position);
        }
    }
}
