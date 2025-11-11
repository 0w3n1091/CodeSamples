using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    public interface IInventoryItem
    {
        string InstanceId { get; }
        string PatternId { get; }
        int StackSize { get; }
        int Stack { get; set; }
        Sprite Icon { get; }
        InventorySlotType BackpackSlotType { get; }
        bool IsFull { get; }
    }
}