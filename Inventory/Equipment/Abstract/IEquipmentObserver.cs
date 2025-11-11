using Core.Equipment.Slots;
using UniRx;

namespace Core.Equipment.Equipment
{
    public interface IEquipmentObserver
    {
        /// <summary>
        /// Observable property that emits when an item is equipped, providing both the slot and the equipped item.
        /// </summary>
        IReadOnlyReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> OnEquip { get; }

        /// <summary>
        /// Observable property that emits when an item is unequipped, providing both the slot and the unequipped item.
        /// </summary>
        IReadOnlyReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> OnUnequip { get; }
    }
}