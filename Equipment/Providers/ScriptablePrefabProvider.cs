using UnityEngine;

namespace Core.Providers
{
    public abstract class ScriptablePrefabProvider<TKey> : ScriptableProvider<TKey,GameObject>, IPrefabProvider<TKey>
    {
    }
}