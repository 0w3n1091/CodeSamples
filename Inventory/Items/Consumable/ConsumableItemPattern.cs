using UnityEngine;

namespace Core.Equipment
{
    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Items/ConsumableItem", fileName = "Create Consumable Item", order = 1)]
    public class ConsumableItemPattern : InventoryItemPattern
    {
        public override IInventoryItem CreateInstance() => new ConsumableItem(this);
    }
}