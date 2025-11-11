using System.Collections.Generic;
using System.Linq;
using Core.Equipment.Providers;
using Core.Equipment.Slots;
using UniRx;

namespace Core.Equipment.Equipment
{
    internal class Equipment : IEquipment
    {
        public IReadOnlyReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> OnEquip => onEquip;
        public IReadOnlyReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> OnUnequip => onUnequip;

        private readonly ReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> onEquip = new ReactiveProperty<(EquipmentSlot, IEquipmentItem)>();
        private readonly ReactiveProperty<(EquipmentSlot slot, IEquipmentItem item)> onUnequip = new ReactiveProperty<(EquipmentSlot, IEquipmentItem)>();
        
        private readonly EquipmentSlotProvider slotProvider;
        private readonly Dictionary<EquipmentSlot, IEquipmentItem> items = new Dictionary<EquipmentSlot, IEquipmentItem>();
        
        internal Equipment(EquipmentSlotProvider slotProvider)
        {
            this.slotProvider = slotProvider;
            foreach (var slot in slotProvider.Get())
                items.Add(slot, null);
        }
        
        public void Equip(EquipmentSlot slot, IEquipmentItem item)
        {
            items[slot] = item;
            onEquip.SetValueAndForceNotify((slot, item));
        }

        public IEquipmentItem Unequip(EquipmentSlot slot)
        {
            var item = items[slot];
            
            onUnequip.SetValueAndForceNotify((slot, items[slot]));
            items[slot] = null;

            return item;
        }

        public void Unequip(IEquipmentItem item)
        {
            foreach (var pair in items)
            {
                if (!Equals(pair.Value, item))
                    continue;

                Unequip(pair.Key);
                break;
            }
        }

        public IEnumerable<IEquipmentItem> InSlot(EquipmentSlotType slot)
        {
            return (from equipmentSlot in items.Keys where equipmentSlot.Type == slot select items[equipmentSlot]).ToList();
        }
        
        public bool IsEmpty(EquipmentSlot slot) => items[slot] == null;
        
        public EquipmentSlot GetFirstOrEmptySlot(EquipmentSlotType slotType)
        {
            var slots = slotProvider.Get(slotType);
            
            foreach (EquipmentSlot slot in slots)
            {
                if (items[slot] == null)
                    return slot;
            }

            return slots.FirstOrDefault();
        }

        public bool Equipped(IEquipmentItem item)
        {
            foreach (var slotItem in items.Values)
            {
                if (item == null)
                    return false;

                if (item.Equals(slotItem))
                    return true;
            }

            return false;
        }
    }
}