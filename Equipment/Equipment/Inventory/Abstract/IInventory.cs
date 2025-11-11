using Core.Equipment.Backpack;
using Core.Equipment.Equipment;

namespace Core.Equipment.Inventory
{
    public interface IInventory
    {
        /// <summary>
        /// Gets the backpack observer interface for monitoring backpack-related events.
        /// </summary>
        public IBackpackObserver Backpack { get; }

        /// <summary>
        /// Gets the equipment observer interface for monitoring equipment-related events.
        /// </summary>
        public IEquipmentObserver Equipment { get; }

        /// <summary>
        /// Adds a specified amount of items with the given ID to the inventory.
        /// </summary>
        /// <param name="id">The pattern ID of the item to add.</param>
        /// <param name="amount">The amount of items to add. Defaults to 1.</param>
        public void Add(string id, int amount = 1);

        /// <summary>
        /// Removes a specified amount of the given item from the inventory.
        /// </summary>
        /// <param name="item">The item to remove.</param>
        /// <param name="amount">The amount to remove. Defaults to 1.</param>
        public void Remove(IInventoryItem item, int amount = 1);

        /// <summary>
        /// Equips the specified equipment item, moving it from the backpack to the appropriate equipment slot.
        /// </summary>
        /// <param name="item">The equipment item to equip.</param>
        public void Equip(IEquipmentItem item);

        /// <summary>
        /// Unequips the specified equipment item, moving it from the equipment slot to the backpack.
        /// </summary>
        /// <param name="item">The equipment item to unequip.</param>
        public void Unequip(IEquipmentItem item);

        /// <summary>
        /// Checks if the specified equipment item is currently equipped.
        /// </summary>
        /// <param name="item">The equipment item to check.</param>
        /// <returns>True if the item is equipped; otherwise, false.</returns>
        bool Equipped(IEquipmentItem item);
    }
}