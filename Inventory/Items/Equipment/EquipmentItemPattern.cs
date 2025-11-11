using Core.Equipment.Slots;
using UnityEngine;

namespace Core.Equipment
{
    [CreateAssetMenu(menuName = "RPG Libraries/Equipment/Items/EquipmentItem", fileName = "Create Equipment Item", order = 0)]
    public class EquipmentItemPattern : InventoryItemPattern
    {
        [Header("Equipment Item")]
        [field: SerializeField] public EquipmentSlotType EquipmentSlotType { get; private set; }

        public override IInventoryItem CreateInstance() => new EquipmentItem(this);

        protected virtual void OnValidate()
        {
            base.OnValidate();
            StackSize = 1;
        }
    }
}

