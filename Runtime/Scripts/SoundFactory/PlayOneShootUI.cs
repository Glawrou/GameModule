namespace naa.Module
{
    public class PlayOneShootUI : PlayOneShoot 
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
