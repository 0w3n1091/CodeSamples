using UnityEngine;

namespace Core.Equipment.Slots
{
    public enum EquipmentSlotType { Helmet, Amulet, Shoulders, Chest, Gloves, Boots, Ring, Weapon, Shield, Trinket }

    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Slots/Create Equipment Slot", fileName = "Slot")]
    public class EquipmentSlot : Slot<EquipmentSlotType> 
    {
        public string Name => Type.ToString();
    }
}