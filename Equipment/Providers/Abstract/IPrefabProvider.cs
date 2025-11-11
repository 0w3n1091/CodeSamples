using UnityEngine;

namespace Core.Providers
{
    public interface IPrefabProvider<in TKey> : IProvider<TKey,GameObject>
    {
        
    }
}