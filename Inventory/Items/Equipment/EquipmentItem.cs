using System;
using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    public class EquipmentItem : IEquipmentItem
    {
        public EquipmentItem(EquipmentItemPattern pattern)
        {
            InstanceId = Guid.NewGuid().ToString();
            PatternId = pattern.Id;
            StackSize = pattern.StackSize;
            Icon = pattern.Icon;
            BackpackSlotType = pattern.InventorySlotType;
            EquipmentSlotType = pattern.EquipmentSlotType;
        }

        public string InstanceId { get; }
        public string PatternId { get; }
        public int StackSize { get; }
        public int Stack { get; set; } = 1;
        public bool IsFull => Stack == StackSize;
        public Sprite Icon { get; }
        public InventorySlotType BackpackSlotType { get; }
        public EquipmentSlotType EquipmentSlotType { get; }
        
        public override bool Equals(object obj)
        {
            if (obj is EquipmentItem other)
                return InstanceId == other.InstanceId;
            
            return false;
        }

        public override int GetHashCode() => InstanceId.GetHashCode();
    }
}