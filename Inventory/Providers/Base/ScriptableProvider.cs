using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Providers
{
    public abstract class ScriptableProvider<TKey,TValue> : SerializedScriptableObject, IProvider<TKey,TValue>
    {
        [SerializeField] private TValue defaultValue;
        [SerializeField] protected Dictionary<TKey, TValue> repository = new();
        
        public TValue Get(TKey key) => repository.GetValueOrDefault(key,defaultValue);
        public List<TValue> Get() => repository.Values.ToList();
    }
}