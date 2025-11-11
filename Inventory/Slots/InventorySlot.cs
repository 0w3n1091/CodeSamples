using UnityEngine;

namespace Core.Equipment.Slots
{
    public enum InventorySlotType { Armor, Weapon, Jewelery, Consumable }

    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Slots/Create Inventory Slot", fileName = "Slot")]
    public class InventorySlot : Slot<InventorySlotType>
    {
    }
}