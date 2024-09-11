using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    public SaveData SaveData { get; set; }

    private const string SaveDataKey = "MainSaveData";

    private void Awake()
    {
        transform.parent = null;
        DontDestroyOnLoad(gameObject);
        InitSave();
    }

    private void InitSave()
    {
        LoadSave();
    }

    private void LoadSave()
    {
        var save = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(SaveDataKey));
        if (save == null)
        {
            save = new SaveData();
        }

        SaveData = save;
    }

    public void Save()
    {
        PlayerPrefs.SetString(SaveDataKey, JsonUtility.ToJson(SaveData));
    }

    public void Clear()
    {
        LoadSave();
        PlayerPrefs.DeleteAll();
    }
}
