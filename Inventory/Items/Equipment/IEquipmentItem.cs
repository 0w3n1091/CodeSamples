using Core.Equipment.Slots;

namespace Core.Equipment
{
    public interface IEquipmentItem : IInventoryItem
    {
        EquipmentSlotType EquipmentSlotType { get; }
    }
}