using System.Collections.Generic;
using Core.Equipment.Slots;

namespace Core.Equipment.Equipment
{
    public interface IEquipment : IEquipmentObserver
    {
        /// <summary>
        /// Equips an item to the specified equipment slot.
        /// </summary>
        /// <param name="slot">The equipment slot where the item will be equipped.</param>
        /// <param name="item">The equipment item to be equipped into the specified slot.</param>
        void Equip(EquipmentSlot slot, IEquipmentItem item);

        /// <summary>
        /// Unequips an item from the specified equipment slot.
        /// </summary>
        /// <param name="slot">The equipment slot to unequip the item from.</param>
        /// <returns>The unequipped item from the specified slot.</returns>
        IEquipmentItem Unequip(EquipmentSlot slot);

        /// <summary>
        /// Unequips the specified equipment item.
        /// </summary>
        /// <param name="item">The equipment item to be unequipped.</param>
        void Unequip(IEquipmentItem item);

        /// <summary>
        /// Gets the collection of equipment items located in the specified slot type.
        /// </summary>
        /// <param name="slotType">The type of the equipment slot to retrieve items from.</param>
        /// <returns>A collection of equipment items located in the specified slot type.</returns>
        IEnumerable<IEquipmentItem> InSlot(EquipmentSlotType slotType);

        /// <summary>
        /// Determines whether the specified equipment slot is empty.
        /// </summary>
        /// <param name="slot">The equipment slot to check for emptiness.</param>
        /// <returns>True if the specified slot is empty; otherwise, false.</returns>
        bool IsEmpty(EquipmentSlot slot);

        /// <summary>
        /// Checks if the specified equipment item is currently equipped.
        /// </summary>
        /// <param name="item">The equipment item to check for its equipped status.</param>
        /// <returns>True if the item is equipped, otherwise false.</returns>
        bool Equipped(IEquipmentItem item);

        /// <summary>
        /// Retrieves the first available or empty slot of the specified equipment slot type.
        /// </summary>
        /// <param name="slotType">The type of the equipment slot to be searched for.</param>
        /// <returns>The first available or empty equipment slot of the specified type.</returns>
        EquipmentSlot GetFirstOrEmptySlot(EquipmentSlotType slotType);
    }
}