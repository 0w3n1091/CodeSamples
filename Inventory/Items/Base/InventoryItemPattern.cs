using System;
using Core.Equipment.Slots;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Equipment
{
    public abstract class InventoryItemPattern : SerializedScriptableObject, IInventoryItemPattern
    {
        [Header("Item Pattern")]
        [field: SerializeField, ReadOnly] public string Id { get; private set; }
        [field: SerializeField] public virtual int StackSize { get; protected set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public InventorySlotType InventorySlotType { get; private set; }
        
        public abstract IInventoryItem CreateInstance();
        
        protected virtual void OnValidate()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = Guid.NewGuid().ToString();
                Debug.Log($"Generated unique ID for {name}: {Id}");
            }
        }
    }
}