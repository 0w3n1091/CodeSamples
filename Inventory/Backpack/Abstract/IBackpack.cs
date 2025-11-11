namespace Core.Equipment.Backpack
{
    public interface IBackpack : IBackpackObserver
    {
        /// <summary>
        /// Inserts a new item instance into the backpack.
        /// </summary>
        /// <param name="item">The inventory item to insert.</param>
        void Insert(IInventoryItem item);
        
        /// <summary>
        /// Removes an item instance from the backpack.
        /// </summary>
        /// <param name="item">The inventory item to remove.</param>
        void Remove(IInventoryItem item);
        
        /// <summary>
        /// Adds a specified amount to an item's stack in the backpack.
        /// </summary>
        /// <param name="item">The inventory item to add to.</param>
        /// <param name="amount">The amount to add to the item's stack.</param>
        /// <returns>The remaining amount that couldn't be added due to stack limitations.</returns>
        int Add(IInventoryItem item, int amount = 1);
        
        /// <summary>
        /// Subtracts a specified amount from an item's stack in the backpack.
        /// </summary>
        /// <param name="item">The inventory item to subtract from.</param>
        /// <param name="amount">The amount to subtract from the item's stack.</param>
        /// <returns>The remaining amount that couldn't be subtracted.</returns>
        int Subtract(IInventoryItem item, int amount = 1);
        
        /// <summary>
        /// Checks if an item with the specified pattern ID exists in the backpack.
        /// </summary>
        /// <param name="patternId">The ID of the item to search for.</param>
        /// <param name="instance">When the method returns, contains the found item instance if found; otherwise, null.</param>
        /// <returns>True if an item with the specified ID exists; otherwise, false.</returns>
        public bool Exists(string patternId, out IInventoryItem instance);

        /// <summary>
        /// Checks if the specified item exists in the backpack.
        /// </summary>
        /// <param name="item">The item to search for.</param>
        /// <returns>True if the item exists in the backpack; otherwise, false.</returns>
        public bool Exists(IInventoryItem item);
    }
}