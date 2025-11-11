using System.Linq;
using Core.Equipment.Backpack;
using Core.Equipment.Equipment;
using Core.Equipment.Providers;
using Core.Equipment.Slots;

namespace Core.Equipment.Inventory
{
    public class Inventory : IInventory
    {
        public IBackpackObserver Backpack => backpack;
        public IEquipmentObserver Equipment => equipment;
        
        private readonly IBackpack backpack;
        private readonly IEquipment equipment;
    
        private readonly ItemPatternProvider itemPatternProvider;
        private readonly ItemPatternProvider patternProvider;
        private readonly EquipmentSlotProvider equipmentSlotProvider;

        public Inventory(ItemPatternProvider patternProvider, IBackpack backpack, IEquipment equipment)
        {
            this.patternProvider = patternProvider;
            this.backpack = backpack;
            this.equipment = equipment;
        }
        
        public void Add(string id, int amount = 1)
        {
            if (amount < 1)
                return;
            
            if (backpack.Exists(id, out IInventoryItem item) && !item.IsFull)
            {
                amount = backpack.Add(item, amount);
                if (amount == 0)
                    return;
            }
        
            var pattern = patternProvider.Get(id);
            item = pattern.CreateInstance();
            
            backpack.Insert(item);
            amount = backpack.Add(item, amount - 1);
            
            if (amount <= 0)
                return;
         
            Add(id, amount);
        }
        
        public void Remove(IInventoryItem item, int amount = 1)
        {
            if (amount < 1)
                return;

            if (!backpack.Exists(item))
                return;

            RecursiveRemove(item, amount);
        }
        
        public void Equip(IEquipmentItem item)
        {
            if (item.GetType() == typeof(WeaponItem))
            {
                EquipWeapon(item as WeaponItem);
                backpack.Remove(item);
                return;
            }

            EquipItem(item);
            backpack.Remove(item);
        }

        public void Unequip(IEquipmentItem item)
        {
            equipment.Unequip(item);
            backpack.Insert(item);
        }

        public bool Equipped(IEquipmentItem item) => equipment.Equipped(item);

        private void RecursiveRemove(IInventoryItem item, int amount)
        {
            var change = backpack.Subtract(item, amount);

            if (item.Stack == 0)
                backpack.Remove(item);
        
            if (change == 0)
                return;
        
            if (backpack.Exists(item.PatternId, out IInventoryItem newItem))
                RecursiveRemove(newItem, change);
        }

        private void EquipItem(IEquipmentItem item)
        {
            var slot = equipment.GetFirstOrEmptySlot(item.EquipmentSlotType);

            if (!equipment.IsEmpty(slot))
            {
                var equippedItem = equipment.Unequip(slot);
                backpack.Insert(equippedItem);
            }
            
            equipment.Equip(slot, item);
        }

        private void EquipWeapon(WeaponItem item)
        {
            // Clear off hand first
            if (item.WeaponType == WeaponType.TwoHanded)
            {
                var offHand = equipment.InSlot(EquipmentSlotType.Shield).FirstOrDefault();
                if (offHand != null)
                    equipment.Unequip(offHand);
            }
            
            EquipItem(item);
        } 
    }
}