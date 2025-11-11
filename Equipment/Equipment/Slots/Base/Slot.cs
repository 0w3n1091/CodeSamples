using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Equipment.Slots
{
    public class Slot<T> : SerializedScriptableObject where T : Enum
    {
        [field: SerializeField] public T Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}