using System.Collections.Generic;
using System.Linq;
using Core.Equipment.Slots;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Core.Equipment.Providers
{
    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Providers/Equipment Slot Provider", fileName = "Equipment Slot Provider", order = 1)]
    public class EquipmentSlotProvider : SerializedScriptableObject
    {
        [SerializeField] private List<EquipmentSlot> equipmentSlots = new List<EquipmentSlot>();
    
        public IEnumerable<EquipmentSlot> Get(EquipmentSlotType equipmentSlotType)
        {
            return equipmentSlots.Where(s => s.Type == equipmentSlotType);
        }

        public List<EquipmentSlot> Get() => equipmentSlots;
    }
}