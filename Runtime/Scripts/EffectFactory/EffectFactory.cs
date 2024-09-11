using System;
using System.Linq;
using UnityEngine;

public class EffectFactory : MonoBehaviour
{
    [SerializeField] private EffectData[] _effectStorage;

    public void Effect(string key, Transform perent)
    {
        Effect(key, perent.position, perent);
    }

    public void Effect(string key, Vector3 position)
    {
        Effect(key, position, transform);
    }

    public void Effect(string key, Vector3 position, Transform perent)
    {
        var effectData = GetEffect(key);
        if (effectData == null)
        {
            return;
        }

        SpawnEffect(effectData.ParticleSystem, position, perent);
    }

    private bool CheackEffect(string key)
    {
        return _effectStorage.Any(e => e.Key.Equals(key));
    }

    private EffectData GetEffect(string key)
    {
        if (!CheackEffect(key))
        {
            Debug.LogError($"EffectFactory >> GetEffect >> [Effect is not found]");
            return null;
        }

        return _effectStorage.FirstOrDefault(e => e.Key.Equals(key));
    }

    private void SpawnEffect(ParticleSystem particleSystem, Vector3 position, Transform parent)
    {
        Instantiate(particleSystem, position, Quaternion.identity, parent);
    }
}

[Serializable]
public class EffectData
{
    public string Key;
    public ParticleSystem ParticleSystem;
}
