using System.Collections.Generic;
using System.Linq;
using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment.Providers
{
    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Providers/Inventory Slot Provider", fileName = "Inventory Slot Provider", order = 0)]
    public class InventorySlotProvider : SlotProvider<InventorySlotType, InventorySlot> 
    {
        public List<InventorySlotType> GetSlotTypes() => repository.Keys.ToList();
    }
}