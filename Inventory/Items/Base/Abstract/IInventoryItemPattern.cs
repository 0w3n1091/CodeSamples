using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    public interface IInventoryItemPattern
    {
        string Id { get; }
        int StackSize { get; }
        Sprite Icon { get; }
        InventorySlotType InventorySlotType { get; }
        IInventoryItem CreateInstance();
    }
}