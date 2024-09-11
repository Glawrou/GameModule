using System;

[Serializable]
public class SettingsData
{
    public float Sound;
    public float Music;
    public bool IsAgeLimit;
    public string Language;

    public SettingsData()
    {
        Sound = 1f;
        Music = 1f;
        IsAgeLimit = false;
        Language = "en";
    }

    public SettingsData(float sound, float music, bool isAgeLimit, string language)
    {
        Sound = sound;
        Music = music;
        IsAgeLimit = isAgeLimit;
        Language = language;
    }
}
