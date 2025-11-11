using System;
using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    public class WeaponItem : IWeaponItem
    {
        public WeaponItem(WeaponItemPattern pattern)
        {
            InstanceId = Guid.NewGuid().ToString();
            PatternId = pattern.Id;
            StackSize = pattern.StackSize;
            Icon = pattern.Icon;
            BackpackSlotType = pattern.InventorySlotType;
            EquipmentSlotType = pattern.EquipmentSlotType;
            WeaponType = pattern.WeaponType;
        }

        public string InstanceId { get; }
        public string PatternId { get; }
        public int StackSize { get; }
        public int Stack { get; set; } = 1;
        public bool IsFull => Stack == StackSize;
        public Sprite Icon { get; }
        public InventorySlotType BackpackSlotType { get; }
        public EquipmentSlotType EquipmentSlotType { get; }
        public WeaponType WeaponType { get; }
        
        public override bool Equals(object obj)
        {
            if (obj is WeaponItem other)
                return InstanceId == other.InstanceId;
            
            return false;
        }

        public override int GetHashCode() => InstanceId.GetHashCode();
    }
}