using System;

[Serializable]
public class SaveData
{
    public SettingsData Settings;

    public SaveData()
    {
        Settings = new SettingsData();
    }
}
