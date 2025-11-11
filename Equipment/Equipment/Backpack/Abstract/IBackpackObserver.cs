using UniRx;

namespace Core.Equipment.Backpack
{
    public interface IBackpackObserver
    {
        /// <summary>
        /// Observable property that emits when a new item is created in the backpack.
        /// </summary>
        public IReadOnlyReactiveProperty<IInventoryItem> OnItemCreated { get; }

        /// <summary>
        /// Observable property that emits when an item is removed from the backpack.
        /// </summary>
        public IReadOnlyReactiveProperty<IInventoryItem> OnItemRemoved { get; }

        /// <summary>
        /// Observable property that emits when an item's stack amount is updated in the backpack.
        /// Provides both the updated item and its new amount.
        /// </summary>
        public IReadOnlyReactiveProperty<(IInventoryItem item, int amount)> OnItemUpdated { get; }
    }
}