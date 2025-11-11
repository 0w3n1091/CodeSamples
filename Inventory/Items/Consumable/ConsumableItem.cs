using System;
using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    public class ConsumableItem : IConsumableItem
    {
        public ConsumableItem(ConsumableItemPattern pattern)
        {
            InstanceId = Guid.NewGuid().ToString();
            PatternId = pattern.Id;
            StackSize = pattern.StackSize;
            Icon = pattern.Icon;
            BackpackSlotType = pattern.InventorySlotType;
        }

        public string InstanceId { get; }
        public string PatternId { get; }
        public int StackSize { get; }
        public int Stack { get; set; } = 1;
        public Sprite Icon { get; }
        public InventorySlotType BackpackSlotType { get; }
        public bool IsFull => Stack == StackSize;

        public override bool Equals(object obj)
        {
            if (obj is ConsumableItem other)
                return InstanceId == other.InstanceId;
            
            return false;
        }

        public override int GetHashCode() => InstanceId.GetHashCode();
    }
}